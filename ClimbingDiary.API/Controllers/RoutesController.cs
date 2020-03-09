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
            var routesFromSectorRepo = _climbingDiaryRepository.GetRoutes(sectorId);
            return Ok(_mapper.Map<IEnumerable<RouteDto>>(routesFromSectorRepo));
        }
        [HttpGet("{routeId}",Name = "GetRouteFromSector")]
        public ActionResult<RouteDto> GetRouteFromSector(Guid sectorId, Guid routeId)
        {
            if (!_climbingDiaryRepository.SectorExists(sectorId))
            {
                return NotFound();
            }
            var routeFromSectorRepo = _climbingDiaryRepository.GetRoute(sectorId,routeId);
            if (routeFromSectorRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RouteDto>(routeFromSectorRepo));
        }
        [HttpPost]
        public ActionResult<RouteDto> CreateRouteFromSector(Guid sectorId, RouteForCreationDto route)
        {
            if (!_climbingDiaryRepository.SectorExists(sectorId))
            {
                return NotFound();
            }
            var routeEntity = _mapper.Map<Entities.Route>(route);
            _climbingDiaryRepository.AddRoute(sectorId, routeEntity);
            _climbingDiaryRepository.Save();

            var routeToReturn = _mapper.Map<RouteDto>(routeEntity);
            return CreatedAtRoute("GetRouteFromSector", new { sectorId = sectorId, routeId = routeToReturn.Id }, routeToReturn);
        }
    }
}
