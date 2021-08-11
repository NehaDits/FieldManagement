using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Response
{
    public class EstimationSaveDTO
    {
        public int EstimationId { get; set; }
        public decimal? EstimationAmount { get; set; }
        public int JobOrderID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
