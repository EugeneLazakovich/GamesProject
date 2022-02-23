using CoreBL;
using GamesHM1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesHM1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : Controller
    {
        private readonly SaleService _saleService;
        private readonly ILogger<SalesController> _logger;

        public SalesController(ILogger<SalesController> logger, SaleService saleService)
        {
            _logger = logger;
            _saleService = saleService;
        }

        [HttpPost("add")]
        public IActionResult AddSale(Guid gameId, Guid userId, decimal price)
        {
            Guid[] createdGuids;
            try
            {
                createdGuids = _saleService.AddSale(gameId, userId, price);
                var sale = _saleService.GetById(gameId, userId);

                return Created(createdGuids.ToString(), sale);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllSales()
        {
            return Ok(_saleService.GetAllSales());
        }

        [HttpGet]
        public IActionResult GetSaleById(Guid gameId, Guid userId)
        {
            var sale = _saleService.GetById(gameId, userId);
            if (sale != null)
            {
                return Ok(sale);
            }
            return NotFound();
        }

        [HttpGet("today")]
        public IActionResult GetSalesByUserToday(Guid userId)
        {
            var sales = _saleService.GetAllByUserAndToday(userId);
            if(sales.Any())
            {
                return Ok(sales);
            }
            return NotFound();
        }

        //[HttpPut]
        //public IActionResult UpdateSale(Game game, User user, decimal price)
        //{
        //    var sale = _saleService.GetById(game.Id, user.Id);
        //    if(sale != null)
        //    {
        //        sale.Price = price;
        //    }
        //    bool successed = sale != null && _saleService.UpdateById(sale);
        //    //if(successed)
        //    //{
        //    //    return Ok(game); 
        //    //}
        //    //return NotFound();
        //    return StatusCode(successed ? 200 : 404);
        //}
    }
}
