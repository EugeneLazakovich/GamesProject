using AutoMapper;
using GamesHM1.Models;
using CoreDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
