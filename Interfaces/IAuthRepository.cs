using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IAuthRepository
    {
        public Task<ActionResult<User>> RegisterNewUser(User user);

        public User Login(UserDto request);
    }
}
