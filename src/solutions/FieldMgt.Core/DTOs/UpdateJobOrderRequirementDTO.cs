using FieldMgt.Core.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs
{
    public class UpdateJobOrderRequirementDTO: UpdateJobOrderRequirementRequestDTO
    {
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
