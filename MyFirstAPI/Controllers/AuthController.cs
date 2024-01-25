using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Domain.Model;
using MyFirstAPI.Application.Services;

namespace MyFirstAPI.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "jow" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Employee());
                return Ok(token);
            }

            return BadRequest("Username or password invalid");
        }
    }
}
