using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Profiles
{
    public class RoutesProfile: Profile
    {
        public RoutesProfile()
        {
            CreateMap<Entities.Route, Models.RouteDto>();
            CreateMap<Models.RouteForCreationDto, Entities.Route>();
        }
    }
}
