using Microsoft.EntityFrameworkCore;
using WebApiSchool.DataAccess;
using WebApiSchool.DataAccess.Models;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Repository
{
    public class PermissionGroupsRepository : BaseRepository<PermissionGroup>,IPermissionGroupsRepository
    {
        public PermissionGroupsRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly AppDbContext _dbContext;

    }
}
