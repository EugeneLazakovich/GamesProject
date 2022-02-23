using System;
using System.ComponentModel.DataAnnotations;

namespace CoreDAL.Entities
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public DateTime DateReleased { get; set; }
        public string SupportEmail { get; set; }
        public int CountBuys { get; set; }
    }
}
