using AutoMapper;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DomainModels;

namespace FieldMgt.Repository.Mappers.VendorMapping
{
    public class CreateVendorMapper:Profile
    {
        public CreateVendorMapper()
        {
            CreateMap<CreateVendorDTO, CreateAddressDTO>().ReverseMap();
            CreateMap<CreateVendorDTO, CreateContactDetailDTO>().ReverseMap();
            CreateMap<CreateVendorDTO, Vendor>().ReverseMap();
        }
    }
}
