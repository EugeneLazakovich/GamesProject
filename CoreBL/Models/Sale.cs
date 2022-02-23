using System;
using System.Collections.Generic;
using System.Text;

namespace GamesHM1.Models
{
    public class Sale
    {
        public Guid GameId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateBuy { get; set; }
        public decimal Price { get; set; }
    }
}
