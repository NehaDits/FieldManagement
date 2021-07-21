using System;
using System.Collections.Generic;
using System.Text;

namespace FieldMgt.Core.DTOs.Response
{
    public class AddressResponseDTO
    {
        public string Address { get; set; }
        public int City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string ZipCode { get; set; }
        public int AddressType { get; set; }
        public int AddressId { get; set; }
    }
}
