using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Response
{
    public class ClientResponseDTO
    {
        public int ClientId { get; set; }
        public string ClienyCompanyName { get; set; }
        public string ClientDescription { get; set; }
        public int? ClientSource { get; set; }
        public string PermanentAddress { get; set; }
        public int PermanentCity { get; set; }
        public int PermanentState { get; set; }
        public int PermanentCountry { get; set; }
        public string PermanentZipCode { get; set; }
        public string CorrespondenceAddress { get; set; }
        public int CorrespondenceCity { get; set; }
        public int CorrespondenceState { get; set; }
        public int CorrespondenceCountry { get; set; }
        public string CorrespondenceZipCode { get; set; }
        public ContactResponseDTO ContactDTO { get; set; }
        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
