using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.Models;
using WebApiSchool.MyLogger;
using WebApiSchool.Repository.Interfaces;
using WebApiSchool.Services.Interfaces;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IRepository<Course> _repository;
        private readonly ILoggerManager _logger;
        private readonly ResponseModel _responseModel;
        private readonly IMapper _mapper;
        private readonly IPostsService _postsService;

        public PostsController(IRepository<Course> repository,
                               ILoggerManager logger,
                               IMapper mapper,
                               ResponseModel responseModel,
                               IPostsService postsService)
        {
            _repository = repository;
            _logger = logger;
            _responseModel = responseModel;
            _mapper = mapper;
            _postsService = postsService;
        }

        [HttpGet("GetPosts")]
        public async Task<ActionResult<ResponseModel>> GetPosts(int page = 1, int pageSize = 10, string search = "")
        {
            try
            {
                var posts = await _postsService.GetPostsAsync(page, pageSize, search);

                if (posts == null || !(posts).Any())
                {
                    return NoContent();
                }

                var postDTOs = _mapper.Map<List<PostDTO>>(posts);

                var response = new
                {
                    posts = postDTOs,
                    totalRecords = posts.Count
                };

                _responseModel.Data = response;

                return Ok(_responseModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred in {nameof(GetPosts)}: {ex.Message}", nameof(PostsController), nameof(GetPosts));
                _responseModel.Status = "Error";
                _responseModel.Message = ex.Message;
                return BadRequest(_responseModel);
            }
        }
    }
}
