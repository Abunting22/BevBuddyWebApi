using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserServices _userServices;
        private readonly IJwtServices _jwtServices;
        private readonly User _user;

        public AuthServices(IAuthRepository authRepository, IUserServices userServices, IJwtServices jwtServices, User user)
        {
            _authRepository = authRepository;
            _userServices = userServices;
            _jwtServices = jwtServices;
            _user = user;
        }

        public async Task<ActionResult<User>> RegisterUserRequest(UserDto request)
        {
            User user = new()
            {
                Username = request.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            return await _authRepository.RegisterNewUser(user);
        }

        public ActionResult<User> VerifyLoginRequest(UserDto request)
        {
            var isLoginValid = _userServices.VerifyUser(request);

            if (isLoginValid == true)
            {
                var token = _jwtServices.GetJwt(_user);

                return new OkObjectResult(new { Token = token });
            }

            return new UnauthorizedResult();
        }
    }
}
