using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiSchool.Controllers;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.Models;
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

        public string GenerateJwtToken(User user)
        {
            try
            {
                var authClaims = new ClaimsIdentity( new[]
                {
                     new Claim(ClaimTypes.Name, user.Username),
                     new Claim(ClaimTypes.Role, user.PermissionGroup.Name),
                     new Claim(ClaimTypes.NameIdentifier, user.GUID.ToString())
                });

                var listPermissions = new List<string>();
                listPermissions.Add("add");

                foreach (var permission in listPermissions)
                {
                    authClaims.AddClaim(new Claim("Permissions", permission));
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = authClaims,
                    Expires = DateTime.Now.AddDays(30),
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
