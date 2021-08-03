namespace FieldMgt.Core.DTOs.Request
{
    public class CreateAddressDTO
    {
        public string Address { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ZipCode { get; set; }
        public int AddressType { get; set; }
        public int AddressId { get; set; }
    }
}
