using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.IRepository;
using WebApplication1.Modules;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    { public readonly IUserRepo repo;
        public UserController(IUserRepo repo) {
            this.repo = repo; 
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var Response = this.repo.Post(user);
            return Ok(Response);
        }
    }
}
