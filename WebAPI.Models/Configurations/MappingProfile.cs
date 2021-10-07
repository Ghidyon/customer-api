using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models.Entities;
using WebAPI.Models.DataTransferObjects;

namespace WebAPI.Models.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, ViewAccountDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.AccountBalance, opt => opt.MapFrom(src => src.Balance));
        }
    }
}
