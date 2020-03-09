using AutoMapper;
using ClimbingDiary.API.Entities;
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
    [ApiController]
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
            
            return Ok(_mapper.Map<IEnumerable<ClimberDto>>(climberFromRepo));
        }
        [HttpGet("{climberId}",Name ="GetClimber")]
        public ActionResult<IActionResult> GetClimber(Guid climberId)
        {
            var climberFromRepo = _climbingDiaryRepository.GetClimber(climberId);

            return Ok(_mapper.Map<IEnumerable<ClimberDto>>(climberFromRepo));
        }
        [HttpPost]
        public ActionResult<ClimberDto> CreateClimber(ClimberForCreationDto climber)
        {
            var climberEntity = _mapper.Map<Climber>(climber);
            _climbingDiaryRepository.AddClimber(climberEntity);
            _climbingDiaryRepository.Save();

            var climberToReturn = _mapper.Map<ClimberDto>(climberEntity);
           return CreatedAtRoute("GetClimber", new { climberId = climberToReturn.Id }, climberToReturn);
        }
    }
}
