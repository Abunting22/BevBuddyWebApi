using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Services
{
    public class UserServices : IUserServices
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserRepository _userRepository;
        private readonly User _user;

        public UserServices(IAuthRepository authRepository, IUserRepository userRepository, User user)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
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

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUserInfo(int userID)
        {
            var user = await _userRepository.GetUserByUserID(userID);

            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return user;
        }

        public async Task<ActionResult<User>> UpdateUser(UserDto request)
        {
            User user = new()
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            return await _userRepository.UpdateUserByUsername(user);
        }

        public async Task<IResult> DeleteUser(UserDto request)
        {
            await _userRepository.DeleteUserByUsername(request);

            return Results.Ok();
        }
    }
}
