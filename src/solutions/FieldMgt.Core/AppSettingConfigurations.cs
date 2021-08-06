using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core
{
    public class AppSettingConfigurations
    {
        public static AppSettings AppSettings { get; set; }
    }

    public class AppSettings
    {
        public string Secret { get; set; }
        public string Timeout { get; set; }
        public bool EnableAPILog { get; set; }
        public string ErrorLoggingType { get; set; }
        public bool EnableSwagger { get; set; }
    }
}
