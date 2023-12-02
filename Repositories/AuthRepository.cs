using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;

namespace BevBuddyWebApi.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly User _user;

        public AuthRepository(IBaseRepository baseRepository, User user)
        {
            _baseRepository = baseRepository;
            _user = user;
        }

        public async Task<ActionResult<User>> RegisterNewUser(User user)
        {
            const string sql = $"""
                INSERT INTO Users (Username, Password, FirstName, LastName, Email)
                VALUES (@Username, @PasswordHash, @FirstName, @LastName, @Email)
                """;
            using var connection = _baseRepository.Connect();
            await connection.QueryAsync(sql, user);

            return user;
        }

        public User Login(UserDto request)
        {
            const string sql = $"""
                SELECT Username, Password
                FROM Users
                WHERE Username = @Username
                """;

            using var connection = _baseRepository.Connect();
            var user = connection.QuerySingleOrDefault<UserDto>(sql, new { request.Username });

            _user.Username = user.Username;
            _user.PasswordHash = user.Password;

            return _user;
        }
    }
}
