using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using BevBuddyWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register([FromBody]UserDto request)
        {
            return await _authServices.RegisterUserRequest(request);
        }

        [HttpPost("Login")]
        public ActionResult<User> Login([FromBody]UserDto request)
        {
            return _authServices.VerifyLoginRequest(request);
        }
    }
}
