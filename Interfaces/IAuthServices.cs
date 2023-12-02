using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IAuthServices
    {
        public Task<ActionResult<User>> RegisterUserRequest(UserDto request);

        public ActionResult<User> VerifyLoginRequest(UserDto request);
    }
}
