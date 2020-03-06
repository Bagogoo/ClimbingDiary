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

        public SectorsController(IClimbingDiaryRepository climbingDiaryRepository)
        {
            _climbingDiaryRepository = climbingDiaryRepository ??
                throw new ArgumentNullException(nameof(climbingDiaryRepository));
        }
        [HttpGet()]
        public IActionResult GetSectors()
        {
            var sectorsFromRepo = _climbingDiaryRepository.GetSectors();
            return Ok(sectorsFromRepo);
        }
        [HttpGet("{sectorId}")]
        public IActionResult GetSector(Guid sectorId)
        {
            var sectorFromRepo = _climbingDiaryRepository.GetSector(sectorId);
            if (sectorFromRepo==null)
            {
                return NotFound();
            }
            return Ok(sectorFromRepo);
        }
    }
}
