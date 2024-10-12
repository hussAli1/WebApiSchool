using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Entities
{
    public class Post
    {
        public Guid Id { get; set; } 

        public string Title { get; set; }

        public string Content { get; set; } 

        public DateTime CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; } 

        public Guid AuthorId { get; set; } 

        public User Author { get; set; } 
    }

}
