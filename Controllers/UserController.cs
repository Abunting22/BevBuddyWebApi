using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userRepository.GetAllUsers();
        }

        [HttpPost("GetUserByUsername")]
        public async Task<IResult> GetUserByUserUsername([FromBody]UserDto request)
        {
            return await _userRepository.GetUserByUsername(request);
        }

        [HttpDelete("DeleteUserByUsername")]
        public async Task<IResult> DeleteUserByUsername(UserDto request)
        {
            return await _userRepository.DeleteUserByUsername(request);
        }
    }
}
