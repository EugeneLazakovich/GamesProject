using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreDAL.Entities
{
    public class SaleDto
    {
        [Key]
        public Guid GameId { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public DateTime DateBuy { get; set; }
        public decimal Price { get; set; }
    }
}
