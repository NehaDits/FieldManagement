using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace FieldMgt.API.Infrastructure.MiddleWares.ErrorDetail
{
    /// <summary>
    /// Give meaning full name
    /// </summary>
    public class FieldMgtExceptions
    {
        public FieldMgtExceptions(string browser,string exceptionuserId, string errorCode, string errorMessage, string exceptionId,string errorDetails = null)
        {
            ExceptionUser = exceptionuserId;
            ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            ErrorDetails = errorDetails;
            Browser = browser;
            ExceptionId = exceptionId;
        }
        public string Browser { get; set; }
        public string ExceptionUser { get; set; }
        public string  ErrorCode { get; set; }
        public string ExceptionId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        public string ExceptionOn { get; set; } = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}
