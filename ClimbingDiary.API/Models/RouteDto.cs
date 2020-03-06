using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Models
{
    public class RouteDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        public string Grade { get; set; }
        
        public string Author { get; set; }
        public Guid SectorId { get; set; }

    }
}
