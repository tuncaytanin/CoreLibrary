using AutoMapper;
using FluentValidationApp.Web.Dtos;
using FluentValidationApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Isim, source => source.MapFrom(x => x.Name))
                .ForMember(dest => dest.Eposta, source => source.MapFrom(x => x.Email))
                .ForMember(dest => dest.Yas, source => source.MapFrom(x => x.Age))
                .ForMember(dest => dest.FullName, source => source.MapFrom(x => x.FullName2()))
                ;

        
        }
    }
}
