using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUsers();

        public Task<IResult> GetUserByUsername(UserDto request);

        public Task<IResult> DeleteUserByUsername(UserDto request);
    }
}
