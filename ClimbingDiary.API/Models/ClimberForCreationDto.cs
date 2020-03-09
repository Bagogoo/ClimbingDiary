using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Models
{
    public class ClimberForCreationDto
    {
    
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Description { get; set; }
    }
}
