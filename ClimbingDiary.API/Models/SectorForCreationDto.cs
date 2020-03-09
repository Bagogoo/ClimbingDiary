using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Models
{
    public class SectorForCreationDto
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
