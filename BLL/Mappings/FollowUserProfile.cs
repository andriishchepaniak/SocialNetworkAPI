using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mappings
{
    public class FollowUserProfile : Profile
    {
        public FollowUserProfile()
        {
            CreateMap<User, FollowUserDTO>();
            CreateMap<FollowUserDTO, User>();
        }
    }
}
