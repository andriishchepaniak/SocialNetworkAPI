using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mappings
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();
        }
    }
}
