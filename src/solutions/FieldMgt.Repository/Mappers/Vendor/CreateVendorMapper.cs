using AutoMapper;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DomainModels;
using FieldMgt.Core.DTOs.Response;

namespace FieldMgt.Repository.Mappers.VendorMapping
{
    public class CreateVendorMapper:Profile
    {
        public CreateVendorMapper()
        {
            CreateMap<CreateVendorDTO, CreateAddressDTO>().ReverseMap();
            CreateMap<CreateVendorDTO, CreateContactDetailDTO>().ReverseMap();
            CreateMap<CreateVendorDTO, Vendor>().ReverseMap();
            CreateMap<VendorResponseDTO, Vendor>().ReverseMap();
        }
    }

}
