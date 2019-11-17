using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            // validate request

            // send our username and check
            username = username.ToLower();

            if(await _repo.UserExists(username)) {
                return BadRequest("Username already exists.");
            }

            var userToCreate = new User
            {
                Username = username
            }

            var createdUser = await _repo.Register(userToCreate, password);

            // return CreatedAtRoute();
            return StatusCode(201);
        }
    }
}