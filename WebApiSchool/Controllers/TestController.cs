using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Net;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.MyLogger;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TestController : ControllerBase
    {
        private readonly IRepository<Course> _repository;
        private readonly ILoggerManager _logger;
        private APIResponse _apiResponse;
        private readonly IMapper _mapper;

        public TestController(IRepository<Course> repository,
            ILoggerManager logger, IMapper mapper, APIResponse apiResponse)
        {
            _repository = repository;
            _logger = logger;
            _apiResponse = apiResponse;
            _mapper = mapper;

        }

        [HttpGet("GetAll", Name = "GetAll")]
        // [Authorize(Roles = CustomRoles.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            try
            {
                //Exception ex = null;
                //_logger.LogError(new EventId(0, "GetAll"), ex,"dxfhdt");

                var list = new List<object>
                    {
                        new { id = 1, name = "Ali", city = "a1" },
                        new { id = 2, name = "Ali", city = "a1" },
                        new { id = 4, name = "Ali4", city = "a14" },
                        new { id = 5, name = "Ali5", city = "a15" },
                        new { id = 6, name = "Ali6", city = "a16" },
                        new { id = 7, name = "Ali7", city = "a17" },
                        new { id = 8, name = "Ali8", city = "a18" },
                        new { id = 9, name = "Ali9", city = "a19" },
                        new { id = 11, name = "Ali11", city = "a111" },
                        new { id = 12, name = "Ali12", city = "a112" },
                    };
                _apiResponse.Data = list;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "TestController");
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }
        [HttpGet("GetPosts")]
        public async Task<ActionResult<APIResponse>> GetPosts(int page = 1, int pageSize = 10)
        {
            // Ensure valid pagination parameters
            if (page < 1 || pageSize < 1)
            {
                _apiResponse.Status = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.Errors.Add("Page and pageSize must be greater than 0.");
                return BadRequest(_apiResponse);
            }

            // Sample data
            var data = Enumerable.Range(1, 50).Select(i => new
            {
                id = i,
                name = $"Ali{i}",
                city = $"a{i}"
            }).ToList();

            // Paginate
            var posts = data
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            _apiResponse.Data = posts;
            _apiResponse.Status = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            return Ok(_apiResponse);
        }


        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<APIResponse>> GetById(int id)
        {
            try
            {
                // Example data list (this would normally come from a database)
                var list = new List<object>
            {
                new { id = 1, name = "Ali", city = "a1" },
                new { id = 2, name = "Ali", city = "a1" },
                new { id = 4, name = "Ali4", city = "a14" },
                new { id = 5, name = "Ali5", city = "a15" },
                new { id = 6, name = "Ali6", city = "a16" },
                new { id = 7, name = "Ali7", city = "a17" },
                new { id = 8, name = "Ali8", city = "a18" },
                new { id = 9, name = "Ali9", city = "a19" },
                new { id = 11, name = "Ali11", city = "a111" },
                new { id = 12, name = "Ali12", city = "a112" },
            };

                // Find the item by id
                var item = list.FirstOrDefault(x => ((dynamic)x).id == id); // Using dynamic to access properties

                if (item == null)
                {
                    _apiResponse.Status = false;
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    _apiResponse.Errors.Add("Item not found");
                    return NotFound(_apiResponse);
                }

                _apiResponse.Data = item;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "TestController");
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }
    }
}
