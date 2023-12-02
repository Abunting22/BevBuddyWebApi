using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepository _baseRepository;
        private readonly User _user;

        public UserRepository(IBaseRepository baseRepository, User user)
        {
            _baseRepository = baseRepository;
            _user = user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            const string sql = "SELECT * FROM Users";

            using var connection = _baseRepository.Connect();
            var users = await connection.QueryAsync<User>(sql);

            return users;
        }

        public async Task<IResult> GetUserByUsername(UserDto request)
        {
            const string sql = $"""
                SELECT UserID, Username, FirstName, LastName, Email
                FROM Users
                WHERE Username = @Username
                """;

            using var connection = _baseRepository.Connect();
            var user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { request.Username });

            return Results.Ok(user);
        }

        public async Task<IResult> DeleteUserByUsername(UserDto request)
        {
            const string sql = $"""
                DELETE FROM Users 
                WHERE Username = @Username
                """;

            using var connection = _baseRepository.Connect();
            await connection.ExecuteAsync(sql, new { request.Username });

            return Results.Ok();
        }
    }
}
