using Microsoft.AspNetCore.Identity;

namespace WebApiSchool.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPostsRepository Posts { get; }
        IPermissionGroupsRepository PermissionGroups { get; }
        int Complete();
        Task<IdentityResult> CompleteAsync();
    }
}
