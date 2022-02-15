using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesHM1.Models
{
    public class Game
    {
        [Required]
        public Guid Id { get; set; }
        [MinLength(2)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Game name is required")]
        public string Name { get; set; }
        public string Company { get; set; }
        public DateTime DateReleased { get; set; }
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string SupportEmail { get; set; }
        [Range(0, 10000000, ErrorMessage = "Buys must be between 0 and 10000000")]
        public int CountBuys { get; set; }
    }
}
