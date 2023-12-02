using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;

namespace BevBuddyWebApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IAuthRepository _authRepository;
        private readonly User _user;

        public UserServices(IAuthRepository authRepository, User user)
        {
            _authRepository = authRepository;
            _user = user;
        }

        public bool VerifyUser(UserDto request)
        {
            _authRepository.Login(request);

            if (request.Username == null ||
                request.Username != _user.Username ||
                request.Password == null ||
                !BCrypt.Net.BCrypt.Verify(request.Password, _user.PasswordHash))
            {
                return false;
            }

            return true;
        }
    }
}
