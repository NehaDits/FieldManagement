using AutoMapper;
using FieldMgt.Core.DTOs.Request;
using FieldMgt.Core.DomainModels;

namespace FieldMgt.Repository.Mappers.UserMapping
{
    public class CreateUserMapper:Profile
    {
        public CreateUserMapper()
        {
            CreateMap<CreateEmployeeDTO, CreateAddressDTO>().ReverseMap();
            CreateMap<CreateEmployeeDTO, CreateContactDetailDTO>().ReverseMap();
            CreateMap<CreateEmployeeDTO, Staff>().ReverseMap();
            CreateMap<CreateEmployeeDTO, ApplicationUser>().ReverseMap();
        }
        
    }
}
