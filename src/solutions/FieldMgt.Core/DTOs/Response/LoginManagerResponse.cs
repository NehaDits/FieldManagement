using System;
using System.Collections.Generic;
using System.Text;

namespace FieldMgt.Core.DTOs.Response
{
    public class LoginManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Role { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string UserId { get; set; }
    }
}
