using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Entities
{
    public class Climber
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string SecondName { get; set; }
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
        [MaxLength(500)]
        public string AboutMe { get; set; }
    }
}
