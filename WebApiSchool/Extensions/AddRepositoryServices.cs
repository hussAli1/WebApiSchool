using WebApiSchool.Repository.Interfaces;
using WebApiSchool.Repository;
using WebApiSchool.Services.Interfaces;
using WebApiSchool.Services;

namespace WebApiSchool.Extensions
{
    public static class AddRepositoryServices
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
