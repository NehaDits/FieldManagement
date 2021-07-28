using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
   public class CreateClientDTO
    {
        public string ClienyCompanyName { get; set; }
        public string ClientDescription { get; set; }
        public int? ClientSource { get; set; }
        public bool? IsActive { get; set; }
        public int? ContactDetailId { get; set; }
        public int? PermanentAddressId { get; set; }
        public int? BillingAddressId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
