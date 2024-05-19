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
using WebApiSchool.Repository;
using WebApiSchool.Repository.Interfaces;
using WebApiSchool.Services;
using WebApiSchool.Services.Interfaces;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        //private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountsController(
            ILoggerManager logger,
            IUserService userService,
            IConfiguration configuration,
            IAuthService authService,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
            //_userService = userService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Please provide username and password");
                }

                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret"));

                var user = await _unitOfWork.Users.LoginUserAsync(model.Username, model.Password);

                if (user != null)
                {
                    var token = _authService.GenerateJwtToken(model.Username, user.PermissionGroup.Name);

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
                _logger.LogError("Login failed: " + ex.Message, "AccountsController");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
