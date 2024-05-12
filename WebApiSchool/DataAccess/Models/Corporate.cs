namespace WebApiSchool.DataAccess.Models
{
    public class Corporate : Participant
    {
        public string? Company { get; set; }
        public string? JobTitle { get; set; }

        public override string ToString()
        {
            return $"{GUID}  | {LName}, {FName} | ({JobTitle}) at {Company}";
        }
    }
}
