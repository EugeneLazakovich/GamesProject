using GamesHM1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesHM1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private static List<Game> _games;
        private readonly ILogger<GamesController> _logger;
        static GamesController()
        {
            _games = new List<Game>();
        }
        public GamesController(ILogger<GamesController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddGame(Game game)
        {
            game.Id = Guid.NewGuid();
            _games.Add(game);

            return Created(game.Id.ToString(), game);
        }

        [HttpGet]
        public IActionResult GetAllGames()
        {
            return Ok(_games);
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(Guid id)
        {
            Game game = _games.FirstOrDefault(game => game.Id == id);
            if(game != null)
            {
                return Ok(game);
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateGame(Game game)
        {
            Game dbGame = _games.FirstOrDefault(c => c.Id == game.Id);
            if(dbGame != null)
            {
                var index = _games.IndexOf(dbGame);
                _games[index] = game;
                return Ok(game);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(Guid id)
        {
            Game game = _games.FirstOrDefault(game => game.Id == id);
            if(game != null)
            {
                _games.Remove(game);
                return Ok(game);
            }
            return NotFound();
        }
    }
}
