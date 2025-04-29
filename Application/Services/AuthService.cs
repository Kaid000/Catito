using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Repositories;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(UserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponse?> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(email, password);
            if (user == null)
            {
                return null;
            }

            return new LoginResponse()
            {
                JwtSecretKey = GenerateJwtToken(user),
            };
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] ?? throw new Exception("JWT SecretKey is missing");
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
