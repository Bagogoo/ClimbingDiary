using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Entities
{
    public class Sector
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [MaxLength(50)]
        public string Category { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public ICollection<Route> Routes { get; set; }
            = new List<Route>();

    }
}
