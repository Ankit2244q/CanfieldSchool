using System.ComponentModel.DataAnnotations;

namespace CanfieldSchool.Models
{
    public class CanfiledStaff
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public Guid EmployeeId { get; set; } = new Guid();
        public string? Address { get; set; }
        public bool IsOnLeave { get; set; }
    }
}
