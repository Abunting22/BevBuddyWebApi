using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();

        public Task<User> GetUserByUsername(string username);

        public Task<ActionResult<User>> UpdateUserByUsername(User user);

        public Task<IResult> DeleteUserByUsername(UserDto request);
    }
}
