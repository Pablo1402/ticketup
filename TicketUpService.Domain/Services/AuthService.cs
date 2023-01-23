using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TicketUpService.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ComputeSha256Hash(string password)
        {
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] hash = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                    builder  .Append(hash[i].ToString("x2"));

                return builder.ToString();
            }

           
        }

        public string GenerateJwtToken(string login, string role)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("userName", login),
                new Claim(ClaimTypes.Role,role)
            };

            var token = new JwtSecurityToken(
                audience:audience,
                issuer:issuer,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials,
                claims: claims);

            var tokenHandler = new  JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
            
        }
    }
}
