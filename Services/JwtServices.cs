using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BevBuddyWebApi.Services
{
    public class JwtServices : IJwtServices
    {
        private readonly IConfiguration _configuration;

        public JwtServices(IConfiguration configuration, User user)
        {
            _configuration = configuration;
        }   

        private string CreateJwt(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

            var issuer = _configuration.GetSection("JwtSettings:Issuer").Value!;
            var audience = _configuration.GetSection("JwtSettings:Audience").Value!;

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value!)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddDays(1)
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string GetJwt(User user)
        {
            return CreateJwt(user);
        }
    }
}
