using System.ComponentModel.DataAnnotations;

namespace WebApiSchool.DTO.Posts
{
    public class PostCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
