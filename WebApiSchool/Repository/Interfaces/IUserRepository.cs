using System.Linq.Expressions;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> LoginUserAsync(string userNmae , string password);
        Task<User> GetUserByUsernameAsync(string username);

    }
}
