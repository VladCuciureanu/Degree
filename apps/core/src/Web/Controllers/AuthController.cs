using AudioStreaming.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AudioStreaming.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _identityService.Login(username, password);

            if (result is null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var result = await _identityService.Register(username, password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { status = "Bad Request", errors = result.Errors });
            }

            return Ok(new { Status = "Success", Message = "User created successfully!" });
        }
    }
}