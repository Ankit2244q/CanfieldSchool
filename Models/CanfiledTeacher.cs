namespace CanfieldSchool.Models
{
    public class CanfiledTeacher
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Stream { get; set; }
        public Guid TeacherId { get; set; }
        public string? Address { get; set; }
        public DateTime JoinedDate { get; set; }
        public bool IsOnLeave { get; set; }

    }
}
