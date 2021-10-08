using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models.DataTransferObjects;
using WebAPI.Models.Entities;

namespace WebAPI.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<Account, ViewAccountDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.AccountBalance, opt => opt.MapFrom(src => src.Balance));

            CreateMap<Transaction, ViewTransactionDto>()
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.TransactionMode, opt => opt.MapFrom(src => src.TransactionMode.ToString()));
        }
    }
}
