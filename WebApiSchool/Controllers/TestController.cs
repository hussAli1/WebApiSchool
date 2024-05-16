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

    //[Authorize(Roles = "admin,user")]
    public class TestController : ControllerBase
    {
        private readonly IRepository<Course> _repository;
        private readonly ILogger _logger;
        private APIResponse _apiResponse;
        private readonly IMapper _mapper;

        public TestController(IRepository<Course> repository,
            ILogger<TestController> logger, IMapper mapper, APIResponse apiResponse)
        {
            _repository = repository;
            _logger = logger;
            _apiResponse = apiResponse;
            _mapper = mapper;

        }

        [HttpGet(Name = "GetAll")]
        //[Authorize(Roles = CustomRoles.Admin)]
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

                object ob = new { id = 2 , name = "Ali" , city = "a1" };
                _apiResponse.Data = ob;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(0, "GetAll"), ex, ex.Message);
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }
    }
}
