using AutoMapper;
using ClimbingDiary.API.Helpers;
using ClimbingDiary.API.Models;
using ClimbingDiary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Controllers
{
    [Route("api/climbers")]
    
    public class ClimbersController:ControllerBase
    {
        private readonly IClimbingDiaryRepository _climbingDiaryRepository;
        private readonly IMapper _mapper;

        public ClimbersController(IClimbingDiaryRepository climbingDiaryRepository, IMapper mapper)
        {
            _climbingDiaryRepository = climbingDiaryRepository ??
                throw new ArgumentNullException(nameof(climbingDiaryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        public ActionResult<IEnumerable<ClimberDto>> GetClimbers()
        {
            var climberFromRepo = _climbingDiaryRepository.GetClimbers();
            var climbers = new List<ClimberDto>();
            
            return Ok(_mapper.Map<IEnumerable<ClimberDto>>(climberFromRepo));
        }
    }
}
