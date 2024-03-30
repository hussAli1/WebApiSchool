using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSchool.Interfaces.ServiceInterface;
using WebApiSchool.Models;
using WebApiSchool.MyLogger;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Course>> GetAll()
        {
            try
            {
                var course = await _service.GetEntityAllAsync();                
                return course;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return default;
            }
        }
    }
}
