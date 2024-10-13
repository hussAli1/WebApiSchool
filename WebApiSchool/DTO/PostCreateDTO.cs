namespace WebApiSchool.DTO
{
    public class PostCreateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
    }
}
