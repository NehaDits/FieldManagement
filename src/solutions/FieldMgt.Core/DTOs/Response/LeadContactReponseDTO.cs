using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Request;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FieldMgt.Core.DTOs.Response
{
    public class LeadContactReponseDTO
    {
        public int LeadContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LeadId { get; set; }
        public CreateContactDetailDTO leadContactDTO { get; set; }
        public AddressResponseDTO addressResponseDTO { get; set; }
        public ICollection<Country> country { get; set; }
        public ICollection<State> state { get; set; }
        public ICollection<City> city { get; set; }
    }
}
