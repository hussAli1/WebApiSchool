﻿using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiSchool.Controllers;
using WebApiSchool.MyLogger;
using WebApiSchool.Services.Interfaces;

namespace WebApiSchool.Services
{

    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly byte[] _key;
        private readonly ILoggerManager _logger;

        public AuthService(IConfiguration configuration , ILoggerManager logger)
        {
            _configuration = configuration;
            _key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret"));
            _logger = logger;
        }

        public string GenerateJwtToken(string username, string role)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
                    }),
                    Expires = DateTime.Now.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to generate JWT token. " + ex.Message , "AuthService");
                throw;
            }
        }
    }
}
