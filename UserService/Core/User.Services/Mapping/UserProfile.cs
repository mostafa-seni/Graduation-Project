using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Entities;
using User.shared.DTOS;

namespace User.Services.Mapping
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDetailsRespones>().
                ForMember(p => p.village, o => o.MapFrom(s => s.Address.Village))
                .ForMember(p => p.Region, o => o.MapFrom(s => s.Address.Region));

            CreateMap<UserDetailsRespones, AppUser>()
                .ForMember(p => p.Address, o => o.MapFrom(s => new Address { Village = s.village, Region = s.Region }));
            CreateMap<AppUser, UserUpdateRequest>();
            CreateMap<UserUpdateRequest, AppUser>();




        }
    }
                  
}
