using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApiSchool.DataAccess.Entities;
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

        public Task<Post> CreatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
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
