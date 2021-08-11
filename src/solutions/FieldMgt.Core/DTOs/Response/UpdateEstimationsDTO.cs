using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Response
{
   public class UpdateEstimationsDTO
    {
        public int EstimationId { get; set; }
        public decimal? EstimationAmount { get; set; }
        public int JobOrderID { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
