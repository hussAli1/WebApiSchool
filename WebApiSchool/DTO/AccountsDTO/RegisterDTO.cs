using System.ComponentModel.DataAnnotations;

namespace WebApiSchool.DTO.Accounts
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}
