namespace WebApiSchool.DataAccess.Models
{
    public class Individual : Participant
    {
        public string University { get; set; }
        public int YearOfGraduation { get; set; }
        public bool IsIntern { get; set; }

        public override string ToString()
        {
            return $"{GUID}  | {LName}, {FName} | Graduted on ({YearOfGraduation}) From {University}" +
                $"({(IsIntern ? "Internship" : "")})";
        }
    }
}
