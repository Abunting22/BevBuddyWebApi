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
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userServices.GetAllUsers();
        }

        [HttpGet("GetUserByUsername")]
        public async Task<IActionResult> GetUserByUserUserID(int userID)
        {
            return Ok(await _userServices.GetUserInfo(userID));
        }

        [HttpPost("UpdateUserByUsername")]
        public async Task<ActionResult<User>> UpdateUserByUsername([FromBody] UserDto request)
        {
            return await _userServices.UpdateUser(request);
        }

        [HttpDelete("DeleteUserByUsername")]
        public async Task<IResult> DeleteUserByUsername([FromBody] UserDto request)
        {
            return await _userServices.DeleteUser(request);
        }
    }
}
