namespace WebApiSchool.DataAccess.Models
{
    public class Enrollment
    {
        public Guid SectionGUID { get; set; }
        public Guid ParticipantGUID { get; set; }

        public Section Section { get; set; } = null!;
        public Participant Participant { get; set; } = null!;
    }
}
