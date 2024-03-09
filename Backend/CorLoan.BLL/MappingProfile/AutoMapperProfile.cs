using AutoMapper;
using CorLoan.BLL.DTOs;
using CorLoan.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CorLoan.BLL.MappingProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerProfile, CustomerProfile_DTO>().ReverseMap();
            CreateMap<IntroducerInfo, IntroducerInfo_DTO>().ReverseMap();          
            CreateMap<AddressList, AddressList_DTO>().ReverseMap();
            
            CreateMap<DivisionInfo, DivisionInfo_DTO>().ReverseMap();
            CreateMap<DistrictInfo, DistrictInfo_DTO>().ReverseMap();
            CreateMap<ThanaInfo, ThanaInfo_DTO>().ReverseMap();
        }
    }
}
