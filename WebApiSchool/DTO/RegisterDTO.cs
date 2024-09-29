using System.ComponentModel.DataAnnotations;

namespace WebApiSchool.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public Guid Role { get; set; } = Guid.Parse("F9F68922-9C6D-4142-BC8C-000AB06B5AB3");
    }
}
