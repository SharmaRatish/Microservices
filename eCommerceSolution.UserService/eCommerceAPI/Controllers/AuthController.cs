using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")] // api/auth
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")] // POST api/auth/register
        public async Task<IActionResult> Register(eCommerce.Core.DTO.RegisterRequest registerRequest)
        { 

            if (registerRequest == null)
            {

                return BadRequest("Invalid registration data");
            }
             AuthenticationResponse? authenticationResponse = await _userService.Register(registerRequest);
            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(eCommerce.Core.DTO.LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {

                return BadRequest("Invalid login data");
            }
            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);
            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
    }
}
