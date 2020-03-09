using AutoMapper;
using ClimbingDiary.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Profiles
{
    public class ClimbersProfiles: Profile
    {
        public ClimbersProfiles()
        {
            CreateMap<Entities.Climber, Models.ClimberDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.SecondName}"))
                .ForMember
                (
                dest => dest.Age,
                opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));



            CreateMap<Models.ClimberForCreationDto, Entities.Climber>();
                
                
        }
    }
}
