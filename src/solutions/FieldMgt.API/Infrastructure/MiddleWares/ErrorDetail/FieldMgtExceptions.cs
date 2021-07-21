using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace FieldMgt.API.Infrastructure.MiddleWares.ErrorDetail
{
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
            //ServiceId = serviceId;
            //LanguageId = languageId;
            //ApplicationId = applicationId;
        }
        public string Browser { get; set; }
        public string ExceptionUser { get; set; }
        public string  ErrorCode { get; set; }
        public string ExceptionId { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorDetails { get; set; }
        public string ExceptionOn { get; set; } = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
        //public object P { get; }

        //public int ApplicationId { get; set; }
        //public int ServiceId { get; set; }
        //public int LanguageId { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
            //var options = new JsonSerializerOptions()
            //{
            //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            //};
            //return JsonSerializer.Serialize(this, options);
        }
    }

}
