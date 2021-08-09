using FieldMgt.Core.DTOs.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs
{
    public class CreateJobOrderDTO:CreateJobOrderRequestDTO
    {
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
