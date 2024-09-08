using Microsoft.AspNetCore.Identity;

namespace WebApiSchool.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
        Task<IdentityResult> CompleteAsync();
    }
}
