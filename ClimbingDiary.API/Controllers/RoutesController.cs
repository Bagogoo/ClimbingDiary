using AutoMapper;
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
    [Route("api/sectors/{sectorId}/routes")]
    public class RoutesController: ControllerBase
    {
        private readonly IClimbingDiaryRepository _climbingDiaryRepository;
        private readonly IMapper _mapper;

        public RoutesController(IClimbingDiaryRepository climbingDiaryRepository, IMapper mapper)
        {
            _climbingDiaryRepository = climbingDiaryRepository ??
                throw new ArgumentNullException(nameof(climbingDiaryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public ActionResult<IEnumerable<RouteDto>> GetRoutesFromSector(Guid sectorId)
        {
            if (!_climbingDiaryRepository.SectorExists(sectorId))
            {
                return NotFound();
            }
            var routesForSectorRepo = _climbingDiaryRepository.GetRoutes(sectorId);
            return Ok(_mapper.Map<IEnumerable<RouteDto>>(routesForSectorRepo));
        }
    }
}
