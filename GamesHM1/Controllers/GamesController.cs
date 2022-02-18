using CoreBL;
using GamesHM1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GamesHM1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly GameService _gameService;
        private readonly ILogger<GamesController> _logger;

        public GamesController(ILogger<GamesController> logger, GameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        [HttpPost("add")]
        public IActionResult AddGame(Game game)
        {
            if (game != null)
            {
                Guid createdGuid;
                try
                {
                    createdGuid = _gameService.AddGame(game);

                    return Created(createdGuid.ToString(), game);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpGet("all")]
        public IActionResult GetAllGames()
        {
            return Ok(_gameService.GetAllGames());
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(Guid id)
        {
            Game game = _gameService.GetGameById(id);
            if (game != null)
            {
                return Ok(game);
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateGame(Game game)
        {
            bool successed = _gameService.UpdateGame(game);
            //if(successed)
            //{
            //    return Ok(game); 
            //}
            //return NotFound();
            return StatusCode(successed ? 200 : 404);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveGame(Guid id)
        {
            var game = _gameService.RemoveGame(id);
            //if(game != null)
            //{
            //    _games.Remove(game);
            //    return Ok(game);
            //}
            //return NotFound();
            return StatusCode(game != null ? 200 : 400, game);
        }
    }
}
