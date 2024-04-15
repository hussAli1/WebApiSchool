using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSchool.Interfaces.ServiceInterface;
using WebApiSchool.Models;
using WebApiSchool.MyLogger;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "Superadmin,Admin")]
    public class CourseController : ControllerBase
    {
        private readonly IService<Course> _service;
        private readonly IMyLogger _logger;
        public CourseController(IService<Course> service , IMyLogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetCourse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Course>> GetAll()
        {
            try
            {
                return await _service.GetEntityAllAsync();                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
