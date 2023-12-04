using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IUserServices
    {
        public bool VerifyUser(UserDto request);

        public Task<IEnumerable<User>> GetAllUsers();

        public Task<User> GetUserInfo(string username);

        public Task<ActionResult<User>> UpdateUser(UserDto request);

        public Task<IResult> DeleteUser(UserDto request);
    }
}
