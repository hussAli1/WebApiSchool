using WebApiSchool.DataAccess.Entities;

namespace WebApiSchool.Repository.Interfaces
{
    public interface IPostsRepository
    {
        Task<List<Post>> SearchAsync(string search, int page, int pageSize);
        Task<int> SearchCountAsync(string search);
    }
}
