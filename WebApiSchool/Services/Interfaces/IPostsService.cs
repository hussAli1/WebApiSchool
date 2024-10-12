using WebApiSchool.DataAccess.Entities;
using WebApiSchool.Models;

namespace WebApiSchool.Services.Interfaces
{
    public interface IPostsService
    {
        Task<List<Post>> GetPostsAsync(int page, int pageSize, string search = "");
        Task<Post> GetPostByIdAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task<Post> UpdatePostAsync(int id, Post post);
        Task<bool> DeletePostAsync(int id);
    }

}
