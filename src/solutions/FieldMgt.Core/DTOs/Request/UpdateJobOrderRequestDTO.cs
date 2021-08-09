using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class UpdateJobOrderRequestDTO
    {
        public string JobOrderDescription { get; set; }
        public int JobOrderId { get; set; }
    }
}
