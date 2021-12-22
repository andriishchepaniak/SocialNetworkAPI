using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
        }
    }
}
