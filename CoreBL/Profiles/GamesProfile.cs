using AutoMapper;
using CoreDAL.Entities;
using GamesHM1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL.Profiles
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<Game, GameDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
                .ForMember(dest => dest.DateReleased, opt => opt.MapFrom(src => src.DateReleased))
                .ForMember(dest => dest.CountBuys, opt => opt.MapFrom(src => src.CountBuys));

            CreateMap<GameDto, Game>();
        }
    }
}
