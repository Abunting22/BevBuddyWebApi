using BevBuddyWebApi.Models;

namespace BevBuddyWebApi.Interfaces
{
    public interface IUserServices
    {
        public bool VerifyUser(UserDto request);
    }
}
