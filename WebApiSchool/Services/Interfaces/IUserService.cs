using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> LoginUserAsync(string userNmae, string password);
    }
}
