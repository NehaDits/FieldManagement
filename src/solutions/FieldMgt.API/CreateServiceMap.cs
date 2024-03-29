﻿//using AutoMapper;
//using FieldMgt.Core.DomainModels;
//using FieldMgt.Core.DTOs.Request;
//using System.ComponentModel;

//namespace FieldMgt
//{
//    public class CreateServiceMap : Profile
//    {
//        public CreateServiceMap()
//        {
//            CreateMap<CreateLeadDTO, Lead>().ReverseMap();
//            CreateMap<CreateLeadContactDTO, LeadContact>().ReverseMap();
//            CreateMap<RegistrationDTO, Staff>().ReverseMap();
//            CreateMap<CreateAddressDTO, AddressDetail>().ReverseMap();
//            //CreateMap<CreateVendorDTO, Vendor>().ReverseMap();
//            CreateMap<CreateContactDetailDTO, ContactDetail>().ReverseMap();
//            CreateMap<CreateContactDetailDTO, CreateVendorDTO>().ReverseMap();
//            CreateMap<CreateServiceProviderDTO, ServiceProvider>().ReverseMap();
//            CreateMap<CreateEmployeeDTO, RegistrationDTO>().ReverseMap()
//                 .ForMember(dest => dest.Email, opt => opt.Ignore())
//                .ForMember(dest => dest.Password, opt => opt.Ignore())
//                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore()); ;
//        }
//    }
//    public static class IgnoreNoMapExtensions
//    {
//        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
//            this IMappingExpression<TSource, TDestination> expression)
//        {
//            var sourceType = typeof(TSource);
//            foreach (var property in sourceType.GetProperties())
//            {
//                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
//                NoMapAttribute attribute = (NoMapAttribute)descriptor.Attributes[typeof(NoMapAttribute)];
//                if (attribute != null)
//                    expression.ForMember(property.Name, opt => opt.Ignore());
//            }
//            return expression;
//        }
//        static Mapper InitializeAutomapper()
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.CreateMap<CreateEmployeeDTO, RegistrationDTO>()
//                .IgnoreNoMap(); ;
//            });
//            var mapper = new Mapper(config);
//            return mapper;
//        }
//    }
//}
