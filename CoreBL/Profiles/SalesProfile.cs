using AutoMapper;
using CoreDAL.Entities;
using GamesHM1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL.Profiles
{
    public class SalesProfile : Profile
    {        
        public SalesProfile()
        {
            CreateMap<SaleDto, Sale>();
            CreateMap<Sale, SaleDto>();
        }
    }
}
