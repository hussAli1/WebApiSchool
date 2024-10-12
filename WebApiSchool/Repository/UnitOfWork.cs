using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApiSchool.DataAccess;
using WebApiSchool.Repository.Interfaces;

namespace WebApiSchool.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IUserRepository Users { get; }
        public IPermissionGroupsRepository PermissionGroups { get; }

        public IPostsRepository Posts { get; }

        public UnitOfWork(AppDbContext context, 
            IUserRepository users,
            IPostsRepository posts,
            IPermissionGroupsRepository permissionGroups)
        {
            _context = context;
            Users = users;
            Posts = posts;
            PermissionGroups = permissionGroups;
        }
        public int Complete()
        {
           return _context.SaveChanges();
        }

        public async Task<IdentityResult> CompleteAsync()
        {
            await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            _context.Dispose();
        }
    }
}
