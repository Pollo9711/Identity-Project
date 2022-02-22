using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleIdentityService.Interfaces;
using ExampleIdentityService.Shared;
using Microsoft.AspNetCore.Authorization;

namespace ExampleIdentityService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO request)
        {
            var user = User;
            

            var response = await _identityService.LoginAsync(request);
            if (response != null)
            {
                return Ok(response);
            }

            return BadRequest();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO request)
        {
            var response = await _identityService.RegisterAsync(request);
            return Ok(response);
        }
    }
}
