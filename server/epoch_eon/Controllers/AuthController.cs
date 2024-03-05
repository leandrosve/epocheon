using Microsoft.AspNetCore.Mvc;
using Prueba.Models.DTOs;
using Prueba.Models.DTOs.Auth;
using Prueba.Services.Implementations;
using Prueba.Services.Interfaces;

namespace Prueba.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signup")]
        public IActionResult SignUp(SignupDataDTO signupData)
        {
            _authService.SignUp(signupData);
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult LogIn(LoginRequestDTO loginRequest)
        {
            var res = _authService.LogIn(loginRequest);
            return Ok(res);
        }
    }
}
