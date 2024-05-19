namespace WebApiSchool.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username, string role);
    }
}
