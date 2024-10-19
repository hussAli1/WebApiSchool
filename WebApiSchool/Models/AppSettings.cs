namespace WebApiSchool.Models
{
    public class AppSettings
    {
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int JwtExpireDays { get; set; }
        public int JwtRefreshTokenExpireDays { get; set; }
        public int GridViewPageSize { get; set; }
        public string ApiBaseUrl { get; set; }
    }

}
