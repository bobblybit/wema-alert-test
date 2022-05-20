using AutoMapper;
using OnBoardingService.Data.DTOS;
using OnBoardingService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardingService.MappingProfiles
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<AppUser, CustomerToAddDto>().ReverseMap();
        }
    }
}
