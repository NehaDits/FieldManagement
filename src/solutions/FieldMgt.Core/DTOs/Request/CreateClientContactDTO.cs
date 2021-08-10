using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldMgt.Core.DTOs.Request
{
    public class CreateClientContactDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public string PrimaryPhone { get; set; }
        public string AlternatePhone { get; set; }
        [StringLength(100, MinimumLength = 8)]
        public string PrimaryEmail { get; set; }
        [StringLength(100, MinimumLength = 8)]
        public string AlternateEmail { get; set; }
        public string PermanentAddress { get; set; }
        public int PermanentCity { get; set; }
        public int PermanentState { get; set; }
        public int PermanentCountry { get; set; }
        public string PermanentZipCode { get; set; }

        //public CreateContactDetailDTO CreateContactDetailDTO { get; set; }
        //public CreateAddressDTO createAddressDTO { get; set; }
    }
}
