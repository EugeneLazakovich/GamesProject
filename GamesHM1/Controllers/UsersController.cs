using CoreBL;
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
    public class UsersController : Controller
    {
        private readonly UserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            if (user != null)
            {
                Guid createdGuid;
                try
                {
                    createdGuid = _userService.AddUser(user);

                    return Created(createdGuid.ToString(), user);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            User user = _userService.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            bool successed = _userService.UpdateUser(user);
            //if(successed)
            //{
            //    return Ok(game); 
            //}
            //return NotFound();
            return StatusCode(successed ? 200 : 404);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(Guid id)
        {
            var user = _userService.RemoveUser(id);
            //if(game != null)
            //{
            //    _games.Remove(game);
            //    return Ok(game);
            //}
            //return NotFound();
            return StatusCode(user != null ? 200 : 400, user);
        }
    }
}
