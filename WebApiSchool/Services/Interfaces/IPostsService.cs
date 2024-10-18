using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DTO.Posts;
using WebApiSchool.Models;

namespace WebApiSchool.Services.Interfaces
{
    public interface IPostsService
    {
        Task<Tuple<int, List<Post>>> GetAsync(int page, int pageSize, string search = "");
        Task<Post> GetByIdAsync(Guid id);
        Task<Post> CreateAsync(PostCreateDTO post);
        Task<Post> UpdateAsync(Guid id, PostUpdateDTO post);
        Task<bool> DeleteAsync(Guid id);
    }

}
