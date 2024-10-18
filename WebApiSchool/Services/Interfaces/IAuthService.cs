using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}
