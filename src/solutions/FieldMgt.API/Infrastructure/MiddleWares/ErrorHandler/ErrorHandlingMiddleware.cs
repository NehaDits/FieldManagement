using FieldMgt.API.Infrastructure.Factories.PathProvider;
using FieldMgt.API.Infrastructure.Factories.LogFiles;
using FieldMgt.API.Infrastructure.MiddleWares.ErrorDetail;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;
using Shyjus.BrowserDetection;
using System.Text.Json;
using Newtonsoft.Json;
using FieldMgt.API.Infrastructure.MiddleWares.Exceptions;
using FieldMgt.API.Infrastructure.Services;
using FieldMgt.Core.Interfaces;
using FieldMgt.Core.DomainModels;

namespace FieldMgt.API.Infrastructure.MiddleWares.ErrorHandler
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IPathProvider _pathProvider;
        private readonly ICurrentUserService _currentUser;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IPathProvider pathProvider, ICurrentUserService currentUser)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ErrorHandlingMiddleware>();
            _pathProvider = pathProvider;
            _currentUser = currentUser;
        }

        public async Task Invoke(HttpContext httpContext, IWebHostEnvironment env, IBrowserDetector detector, IExceptionInterface _exceptionService)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, env, detector, _exceptionService);
            }
        }
        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception, IWebHostEnvironment env, IBrowserDetector detector, IExceptionInterface _exceptionService)
        {
            FieldMgtExceptions response;
            string CurrentUserId = _currentUser.GetUserId();
            HttpStatusCode statusCode;
            var exceptionType = exception.GetType();
            CreateLogFiles.CreateFileIfNotExist(_pathProvider);
            long ExceptionId = DateTime.Now.Ticks;
            string Message = String.Empty;
            string BrowserName = "Firefox";
            // string BrowserName = detector.Browser.Name;
            string Log = String.Empty;
            Message = exception.Message;

            if (exception.Message.Contains("network-related"))
            {
                statusCode = HttpStatusCode.InternalServerError;
                Log = JsonConvert.SerializeObject(new { Id = ExceptionId, Browser = BrowserName, Status = statusCode, Error = Message });
            }
            else
            {
                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    statusCode = HttpStatusCode.Forbidden;
                    Log = "You are not authorized";
                }
                else if (exceptionType == typeof(BadRequestException))
                {
                    statusCode = HttpStatusCode.BadRequest;
                    Log = JsonConvert.SerializeObject(new { Id = ExceptionId, Browser = BrowserName, Status = statusCode, Error = JsonConvert.DeserializeObject<FieldMgtExceptions>(Message) });
                }
                else if (exceptionType == typeof(NotFoundException))
                {
                    statusCode = HttpStatusCode.NotFound;
                    //response=new FieldMgtExceptions(new{ exceptionuserId = CurrentUserId,ErrorCode=statusCode.ToString(),ErrorDetails=Message,ErrorMessage=Message,ExceptionId=ExceptionId.ToString(),Browser=BrowserName});
                    //response = new FieldMgtExceptions(new {Err UserId=UserId, Id = ExceptionId, Browser = BrowserName, Status = statusCode, Error = Message });
                    Log = JsonConvert.SerializeObject(new { Id = ExceptionId, Browser = BrowserName, Status = statusCode, Error = Message });
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    Log = "Some unknown error occoured";
                }
                _exceptionService.SaveLogs(new ExceptionLog() { Browser = BrowserName, ExceptionBy = CurrentUserId, ExceptionId = ExceptionId.ToString(), ErrorMessage = Message, ErrorCode = statusCode.ToString(), ErrorDetails = exception.StackTrace.ToString() });
            }
            CreateLogFiles.Log(_pathProvider, Log);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;
            return httpContext.Response.WriteAsync(Log);
        }
    }
}