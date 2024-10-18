using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiSchool.DTO;
using WebApiSchool.DTO.Accounts;
using WebApiSchool.Exceptions;
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
        private readonly IUserService _userService;

        public AccountsController(
            ILoggerManager logger,
            IUserService userService
            )
        {
            _logger = logger;
            _userService = userService;
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
                var result = await _userService.LoginAsync(model);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError("Login failed: " + ex.Message, "AccountsController");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var response = new
            {
                Status = true,
                Message = "API is Running..."
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddUser(RegisterDTO model)
        {
            var result = await _userService.RegisterUserAsync(model);
            return Ok(result); 
            
        }
    } 
}
