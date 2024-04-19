using WebApiSchool.DataAccess.Models;
using WebApiSchool.Repository.Interfaces;
using WebApiSchool.Services.Interfaces;

namespace WebApiSchool.Services
{
    public class UserService : BaseServices<User>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<User> LoginUserAsync(string userNmae, string password)
        {
            return await _repository.LoginUserAsync(userNmae, password);
        }
    }
}
