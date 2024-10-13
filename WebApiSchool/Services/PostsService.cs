using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;
using WebApiSchool.Models;
using WebApiSchool.MyLogger;
using WebApiSchool.Repository;
using WebApiSchool.Repository.Interfaces;
using WebApiSchool.Services.Interfaces;

namespace WebApiSchool.Services
{
    public class PostsService : IPostsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public PostsService(
                  IUnitOfWork unitOfWork, 
                  IMapper mapper,
                  ILoggerManager logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Post> CreatePostAsync(PostCreateDTO postDto)
        {
            var author = await _unitOfWork.Users.GetUserByUsernameAsync(postDto.Username);
            if (author == null)
            {
                throw new ArgumentException("Invalid Username provided");
            }


            var newPost = _mapper.Map<Post>(postDto);

            newPost.AuthorId = author.GUID;
            newPost.Author = author;      

            await _unitOfWork.Posts.CreateAsync(newPost);
            await _unitOfWork.CompleteAsync();

            return newPost; 
        }

        public async Task<bool> DeletePostAsync(Guid id)
        {
            try
            {
                var post = await _unitOfWork.Posts.SelectById(id);

                if (post == null) return false;
                
                _unitOfWork.Posts.Delete(post);
                await _unitOfWork.CompleteAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error Delete post: {ex.Message}", nameof(PostsService), nameof(DeletePostAsync));
                return false;
            }
        }


        public async Task<Post?> GetPostByIdAsync(Guid id)
        {
            var post = await _unitOfWork.Posts.SelectById(id);

            return post; 
        }

        public async Task<List<Post>> GetPostsAsync(int page, int pageSize, string search = "")
        {
            try
            {
                return await _unitOfWork.Posts.SearchAsync(search, page, pageSize);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching posts: {ex.Message}", nameof(PostsService), nameof(GetPostsAsync));
                throw; 
            }
        }

        public Task<Post> UpdatePostAsync(int id, Post post)
        {
            throw new NotImplementedException();
        }
    }
}
