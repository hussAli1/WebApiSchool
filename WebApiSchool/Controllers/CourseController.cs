using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.MyLogger;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "admin,user")]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _repository;
        private readonly ILoggerManager _logger;
        private APIResponse _apiResponse;
        private readonly IMapper _mapper;

        public CourseController(IRepository<Course> repository,
            ILoggerManager logger, IMapper mapper ,APIResponse apiResponse)
        {
            _repository = repository;
            _logger = logger;
            _apiResponse = apiResponse;
            _mapper = mapper;

        }

        [HttpGet(Name = "GetCourse")]
        [Authorize(Roles = CustomRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                var courses = await _repository.GetAllAsync();
                _apiResponse.Data = _mapper.Map<List<CourseDTO>>(courses);
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "CourseController");
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }
    }
}
