using WebApiSchool.DataAccess;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
