using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateEstimationDTO
    {
        public decimal? EstimationAmount { get; set; }
        public int JobOrderId { get; set; }
    }
}
