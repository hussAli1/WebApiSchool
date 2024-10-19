using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        private readonly ILoggerManager _logger;
        private readonly AppSettings _appSettings;

        public AuthService(ILoggerManager logger,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings.Value;
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
                var key = Encoding.ASCII.GetBytes(_appSettings.JwtKey);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = authClaims,
                    Issuer = _appSettings.JwtIssuer,
                    Audience = _appSettings.JwtAudience,
                    Expires = DateTime.Now.AddDays(_appSettings.JwtExpireDays),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
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
