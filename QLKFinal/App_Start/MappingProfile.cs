﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using QLKFinal.DTOS;
using QLKFinal.Models;

namespace QLKFinal.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Suplier, SuplierDto>();
            Mapper.CreateMap<SuplierDto, Suplier>();
            Mapper.CreateMap<Objectss, ObjectssDto>();
            Mapper.CreateMap<ObjectssDto, Objectss>();

            //Dto to Domain
            Mapper.CreateMap<ObjectssDto, Objectss>().ForMember(o => o.Id, opt => opt.Ignore());
            Mapper.CreateMap<SuplierDto, Suplier>().ForMember(s => s.Id, opt => opt.Ignore());
        }

    }
}