using BevBuddyWebApi.Models;

namespace BevBuddyWebApi.Interfaces
{
    public interface IJwtServices
    {
        public string GetJwt(User user);
    }
}
