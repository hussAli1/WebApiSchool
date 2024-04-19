using Microsoft.EntityFrameworkCore;
using WebApiSchool.DataAccess;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly AppDbContext _dbContext;

        public async Task<User> LoginUserAsync(string userNmae, string password)
        {
            return await _dbContext.Users.Include(u => u.PermissionGroup)
                                      .FirstOrDefaultAsync(u => u.Username == userNmae && u.PasswordHash == password);
        }
    }
}
