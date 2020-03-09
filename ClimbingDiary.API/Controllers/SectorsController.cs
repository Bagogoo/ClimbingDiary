using AutoMapper;
using ClimbingDiary.API.Entities;
using ClimbingDiary.API.Models;
using ClimbingDiary.API.ResourceParameters;
using ClimbingDiary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Controllers
{
    [ApiController]
    [Route("api/sectors")]
    public class SectorsController : ControllerBase
    {
        private readonly IClimbingDiaryRepository _climbingDiaryRepository;
        private readonly IMapper _mapper;

        public SectorsController(IClimbingDiaryRepository climbingDiaryRepository, IMapper mapper)
        {
            _climbingDiaryRepository = climbingDiaryRepository ??
                throw new ArgumentNullException(nameof(climbingDiaryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        public ActionResult<IEnumerable<SectorDto>> GetSectors([FromQuery] SectorsResourceParameters sectorsResourceParameters)
        {
            var sectorsFromRepo = _climbingDiaryRepository.GetSectors(sectorsResourceParameters);
            return Ok(_mapper.Map<IEnumerable<SectorDto>>(sectorsFromRepo));
        }
        [HttpGet("{sectorId}",Name ="GetSector")]
        public IActionResult GetSector(Guid sectorId)
        {
            var sectorFromRepo = _climbingDiaryRepository.GetSector(sectorId);
            if (sectorFromRepo==null)
            {
                return NotFound();
            }
            return Ok(sectorFromRepo);
        }
        [HttpPost]
        public ActionResult<SectorDto> CreateSector(SectorForCreationDto sector)
        {
            var sectorEntity = _mapper.Map<Sector>(sector);
            _climbingDiaryRepository.AddSector(sectorEntity);
            _climbingDiaryRepository.Save();

            var sectorToReturn = _mapper.Map<SectorDto>(sectorEntity);
            return CreatedAtRoute("GetSector", new { sectorId = sectorToReturn.Id }, sectorToReturn);
        }
    }
}
