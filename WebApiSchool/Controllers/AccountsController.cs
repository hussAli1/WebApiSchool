using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.MyLogger;
using WebApiSchool.Repository.Interfaces;
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
        private readonly IMapper _mapper;

        public AccountsController(
            ILoggerManager logger,
            IUserService userService,
            IConfiguration configuration,
            IAuthService authService,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
            //_userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUser(RegisterDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid user data.");
                }

                var existingUser = await _unitOfWork.Users.GetUserByUsernameAsync(model.Username);
                if (existingUser != null)
                {
                    return BadRequest("Username already exists.");
                }

                model.Role = Guid.Parse("F9F68922-9C6D-4142-BC8C-000AB06B5AB3");
                var permissionGroup = await _unitOfWork.PermissionGroups.SelectById(model.Role);
                if (permissionGroup == null)
                {
                    return BadRequest("Invalid role or permission group.");
                }

                var userEntity = _mapper.Map<User>(model);
                userEntity.PermissionGroup = permissionGroup;

                await _unitOfWork.Users.CreateAsync(userEntity);
                await _unitOfWork.CompleteAsync();

                return Ok("User added successfully.");

            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to add user: " + ex.Message, "AccountsController");
                return StatusCode(500, "Internal server error");
            }
        }
    } 
}
