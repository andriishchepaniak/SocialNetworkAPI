using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Mappings
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            CreateMap<Adress, AdressDTO>();
            CreateMap<AdressDTO, Adress>();
        }
    }
}
