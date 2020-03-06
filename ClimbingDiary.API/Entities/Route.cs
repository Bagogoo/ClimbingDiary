using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClimbingDiary.API.Entities
{
    public class Route
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Grade { get; set; }
        [MaxLength(50)]
        public string Author { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }
        public Guid SectorId { get; set; }

    }
}
