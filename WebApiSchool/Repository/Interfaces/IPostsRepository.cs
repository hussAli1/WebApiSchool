using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.Repository.Interfaces
{
    public interface IPostsRepository : IRepository<Post>
    {
        Task<List<Post>> SearchAsync(string search, int page, int pageSize);
    }
}
