using AuthService.Application.Auth.Commands.CreateUser;
using AuthService.Application.Auth.Commands.UserLogin;
using AuthService.Application.Auth.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : BaseController
    {
       

        [HttpPost(Name = "Login")]
        public async Task<IActionResult> Adduser([FromBody] CreateUserCommand command)
        {
            var userId = await Mediator.Send(command);
            return Ok(new { Id = userId });
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await Mediator.Send(new GetUserQuery());
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var token = await Mediator.Send(command);
                return Ok(new { Success = true, Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }
    }
}
