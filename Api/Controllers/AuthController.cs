using Application.Contracts;
using Application.ViewModels.AuthModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUser user;

        public AuthController(IUser user)
        {
            this.user = user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginDTO request)
        {
            var results = await user.Login(request);
            return Ok(results);
        }
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterDTO request)
        {
            var results = await user.RegisterUser(request);
            return Ok(results);
        }

    }
}
