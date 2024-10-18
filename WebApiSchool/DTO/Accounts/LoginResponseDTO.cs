namespace WebApiSchool.DTO.Accounts
{
    public class LoginResponseDTO
    {
        public Guid UserGuid { get; set; }
        public string Token { get; set; }
    }
}
