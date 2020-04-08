using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SparkAuto.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public int Year { get; set; }

        public string Colour { get; set; }

        [Required]
        public double Miles { get; set; }

        public string Style { get; set; }
        public string Model { get; set; }
    }
}
