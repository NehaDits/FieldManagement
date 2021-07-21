using System;
using System.Collections.Generic;
using System.Text;

namespace FieldMgt.Core.DTOs.Response
{
    public class UserManagerReponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Id { get; set; }
    }
}
