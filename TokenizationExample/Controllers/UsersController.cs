using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TokenizationExample.Models;

namespace TokenizationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet, Authorize]
        public IActionResult GetStudents()
        {
            List<User> users = new List<User>();
            users.Add(new User("Abhijit", "admin", "admin"));
            users.Add(new User("Satyajit", "aaba", "admin"));
            users.Add(new User("Sangram", "shaggy", "admin"));
            return Ok(users);
        }
    }
}
