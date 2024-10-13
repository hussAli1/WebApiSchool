using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DTO;
using WebApiSchool.Models;

namespace WebApiSchool.Services.Interfaces
{
    public interface IPostsService
    {
        Task<List<Post>> GetPostsAsync(int page, int pageSize, string search = "");
        Task<Post> GetPostByIdAsync(Guid id);
        Task<Post> CreatePostAsync(PostCreateDTO post);
        Task<Post> UpdatePostAsync(int id, Post post);
        Task<bool> DeletePostAsync(Guid id);
    }

}
