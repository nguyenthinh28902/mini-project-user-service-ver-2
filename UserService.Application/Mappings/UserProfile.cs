using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Models.Dtos.User.Identity;
using UserService.Core.Entities;

namespace UserService.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Ánh xạ từ Request sang Entity
            CreateMap<UserRegisterRequest, ApplicationUser>()
                .ReverseMap();
        }
    }
}
