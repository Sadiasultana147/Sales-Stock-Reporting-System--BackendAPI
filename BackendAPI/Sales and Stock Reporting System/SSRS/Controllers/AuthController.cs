using Microsoft.AspNetCore.Mvc;
using SSRS.Application.Features.UserManagement.DTO;
using SSRS.Application.Interface.UserManagement;

namespace SSRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
            => Ok(await _userService.RegisterAsync(dto));

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
            => Ok(await _userService.LoginAsync(dto));
    }
}
