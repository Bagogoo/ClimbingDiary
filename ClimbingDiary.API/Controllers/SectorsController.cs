﻿using AutoMapper;
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
        public ActionResult<IEnumerable<SectorDto>> GetSectors()
        {
            var sectorsFromRepo = _climbingDiaryRepository.GetSectors();
            var sectors = new List<SectorDto>();
            return Ok(_mapper.Map<IEnumerable<SectorDto>>(sectorsFromRepo));
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
