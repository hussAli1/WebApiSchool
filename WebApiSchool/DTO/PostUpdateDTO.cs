namespace WebApiSchool.DTO
{
    public class PostUpdateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid AuthorId { get; set; }
    }
}
