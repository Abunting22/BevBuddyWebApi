using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();

        public Task<User> GetUserByUserID(int userID);

        public Task<ActionResult<User>> UpdateUserByUsername(User user);

        public Task<IResult> DeleteUserByUsername(UserDto request);
    }
}
