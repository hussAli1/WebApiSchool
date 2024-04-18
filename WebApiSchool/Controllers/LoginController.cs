using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.MyLogger;
using WebApiSchool.Services;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IMyLogger _logger;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;
        public LoginController(IMyLogger logger, IConfiguration configuration, AuthService authService)
        {
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
        }
        [HttpPost]
        public ActionResult Login(LoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Please provide username and password");
                }

                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret"));

                if (model.Username == "aa" && model.Password == "aa")
                {
                    var token = _authService.GenerateJwtToken(model.Username, "Admin");

                    var response = new LoginResponseDTO
                    {
                        Username = model.Username,
                        Token = token
                    };

                    return Ok(response);
                }
                else
                {
                    return Unauthorized("Invalid username and password");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Login failed: " + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
