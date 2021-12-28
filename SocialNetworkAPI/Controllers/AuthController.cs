using BLL.DTOs;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUser)
        {
            var result = await _authService.Login(loginUser);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUser)
        {
            var result = await _authService.Register(registerUser);
            return result != null
                ? Ok(result)
                : BadRequest();
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(User.Identity.Name);
        }
    }
}
