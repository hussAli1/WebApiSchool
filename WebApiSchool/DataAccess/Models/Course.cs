namespace WebApiSchool.DataAccess.Models
{
    public class Course
    {
        public Guid GUID { get; set; }
        public string CourseName { get; set; }
        public decimal Price { get; set; }
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
    public class Review : Entity
    {
        public string Feedback { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
