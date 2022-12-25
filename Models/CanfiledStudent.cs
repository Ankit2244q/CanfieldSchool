namespace CanfieldSchool.Models
{
    public class CanfiledStudent
    {
        public int Id { get; set; }

        public int RollNumber { get; set; }

        public string? Name { get; set; }

        public string? FatherName { get; set; }

        public char Section { get; set; }

        public string? Stream { get; set; }

        public string? Address { get; set; }

        public bool IsOnLeave { get; set; }

        public bool IsFeeDue { get; set; }
    }
}
