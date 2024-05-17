using Auth.Service.Data;
using Auth.Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Service.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserRepository _userRepository;

        public UserController(IApplicationUserRepository userRepository) =>
            _userRepository = userRepository;

        [HttpPost("login")]
        public async Task<ActionResult<LoginApplicationUserResponse>> LoginApplicationUser(LoginApplicationUserDTO loginApplicationUserDTO)
        {
            var result = await _userRepository.LoginApplicationUserAsync(loginApplicationUserDTO);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterApplicationUserResponse>> RegisterApplicationUser(RegisterApplicationUserDTO registerApplicationUserDTO)
        {
            var result = await _userRepository.RegisterApplicationUserAsync(registerApplicationUserDTO);
            return Ok(result);
        }
    }
}
