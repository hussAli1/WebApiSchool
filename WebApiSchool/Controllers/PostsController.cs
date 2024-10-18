using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Security.Claims;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO.Posts;
using WebApiSchool.Models;
using WebApiSchool.MyLogger;
using WebApiSchool.Repository;
using WebApiSchool.Repository.Interfaces;
using WebApiSchool.Services;
using WebApiSchool.Services.Interfaces;

namespace WebApiSchool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        private readonly IRepository<Course> _repository;
        private readonly ILoggerManager _logger;
        private readonly ResponseModel _responseModel;
        private readonly IMapper _mapper;
        private readonly IPostsService _postsService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostsController(IRepository<Course> repository,
                ILoggerManager logger,
                IMapper mapper,
                ResponseModel responseModel,
                IPostsService postsService,
                IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _logger = logger;
            _responseModel = responseModel;
            _mapper = mapper;
            _postsService = postsService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetPosts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseModel>> GetPosts(int page = 1, int pageSize = 10, string search = "")
        {
            try
            {

                var result = await _postsService.GetAsync(page, pageSize, search);

                if (result.Item2 == null || !(result.Item2).Any()) return NoContent();
                
                var postDTOs = _mapper.Map<List<PostDTO>>(result.Item2);

                var response = new
                {
                    posts = postDTOs,
                    totalRecords = result.Item1
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

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] PostCreateDTO postDto)
        {
            try
            {
                var newPost = await _postsService.CreateAsync(postDto);

                if (newPost == null)
                {
                    return CreateErrorResponse("Failed to create the post."); 
                }

                var postDTOs = _mapper.Map<PostDTO>(newPost);

                _responseModel.Data = postDTOs;
                _responseModel.Status = "Success";
                _responseModel.Message = "Post created successfully.";

                return Ok(_responseModel); 
            }
            catch (ArgumentException ex)
            {
                return CreateErrorResponse(ex.Message); 
            }
            catch (Exception ex)
            {
                return CreateErrorResponse("An unexpected error occurred."); 
            }
        }

        [HttpPut("UpdatePost/{id}")]
        public async Task<IActionResult> UpdatePost(Guid id, [FromBody] PostUpdateDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                _responseModel.Status = "ValidationFailed";
                _responseModel.Message = "Invalid data.";
                return BadRequest(_responseModel);
            }

            try
            {
                var updatedPost = await _postsService.UpdateAsync(id, postDTO);

                var postDTOs = _mapper.Map<PostDTO>(updatedPost);

                _responseModel.Status = "Success";
                _responseModel.Data = postDTOs;

                return Ok(_responseModel);
            }
            catch (KeyNotFoundException ex)
            {
                _responseModel.Status = "NotFound";
                _responseModel.Message = ex.Message;
                return NotFound(_responseModel);
            }
            catch (Exception ex)
            {
                _responseModel.Status = "Error";
                _responseModel.Message = ex.Message;
                return StatusCode(500, _responseModel);
            }
        }


        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<ResponseModel>> GetById(Guid id)
        {
            try
            {
                var post = await _postsService.GetByIdAsync(id);

                if (post == null)
                {
                    _responseModel.Status = "NotFound";
                    _responseModel.Message = "Post not found by the specified ID.";
                    return NotFound(_responseModel);
                }

                var postDTOs = _mapper.Map<PostDTO>(post);

                _responseModel.Status = "Success";
                _responseModel.Data = postDTOs;

                return Ok(_responseModel);
            }
            catch (Exception ex)
            {
                _responseModel.Status = "Error";
                _responseModel.Message = ex.Message;
                return StatusCode(500, _responseModel);
            }
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _postsService.DeleteAsync(id);

            if (!result)
            {
                return NotFound(new { message = $"Post with id {id} not found or could not be deleted." });
            }

            return Ok(new { message = $"Post with id {id} was deleted successfully." });
        }
    }
}
