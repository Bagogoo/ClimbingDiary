using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Profiles
{
    public class SectorsProfile:Profile
    {
        public SectorsProfile()
        {
            CreateMap<Entities.Sector, Models.SectorDto>();

            CreateMap<Models.SectorForCreationDto, Entities.Sector>();
        }
    }
}
