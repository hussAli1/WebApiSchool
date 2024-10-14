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

        public async Task<Post> CreateAsync(PostCreateDTO postDto)
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

        public async Task<bool> DeleteAsync(Guid id)
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
                _logger.LogError($"An error Delete post: {ex.Message}", nameof(PostsService), nameof(DeleteAsync));
                return false;
            }
        }


        public async Task<Post> GetByIdAsync(Guid id)
        {
            var post = await _unitOfWork.Posts.SelectById(id);
            return post;
        }

        public async Task<Tuple<int, List<Post>>> GetAsync(int page, int pageSize, string search = "")
        {
            try
            {
                var posts =  await _unitOfWork.Posts.SearchAsync(search, page, pageSize);
                var totalPosts = await _unitOfWork.Posts.Count();

                return new Tuple<int, List<Post>>(totalPosts, posts);

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching posts: {ex.Message}", nameof(PostsService), nameof(GetAsync));
                throw; 
            }
        }

        public async Task<Post> UpdateAsync(Guid id, PostUpdateDTO postDTO)
        {
            var existingPost = await _unitOfWork.Posts.SelectById(id);

            if (existingPost == null)
            {
                throw new KeyNotFoundException($"Post with ID {id} not found.");
            }

            var auther = await _unitOfWork.Users.SelectById(postDTO.AuthorId);

            _mapper.Map(postDTO, existingPost);
            existingPost.Author = auther;

            _unitOfWork.Posts.Update(existingPost);
            await _unitOfWork.CompleteAsync();

            return existingPost;
        }
    }
}
