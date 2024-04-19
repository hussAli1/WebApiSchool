using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.MyLogger;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "Superadmin,Admin")]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<Course> _repository;
        private readonly IMyLogger _logger;
        public CourseController(IRepository<Course> repository, IMyLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet(Name = "GetCourse")]
        [Authorize(Roles = CustomRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<Course>> GetAll()
        {
            try
            {
                return await _repository.GetAllAsync();                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
