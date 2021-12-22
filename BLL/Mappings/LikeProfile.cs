using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mappings
{
    public class LikeProfile : Profile
    {
        public LikeProfile()
        {
            CreateMap<Like, LikeDTO>();
            CreateMap<LikeDTO, Like>();
        }
    }
}
