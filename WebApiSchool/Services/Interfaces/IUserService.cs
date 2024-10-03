using WebApiSchool.DataAccess.Models;
using WebApiSchool.DTO;

namespace WebApiSchool.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponseDTO> LoginAsync(LoginDTO model);
        Task<string> RegisterUserAsync(RegisterDTO model);
    }
}
