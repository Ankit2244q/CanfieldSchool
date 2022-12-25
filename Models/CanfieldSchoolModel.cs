using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CanfieldSchool.Models
{
    public class CanfieldSchoolModel

    {
        [Key]
        public int Id { get; set; }
        public CanfiledStudent? Students { get; set; }

        public CanfiledTeacher ? Teachers { get; set; }

        public CanfiledStaff ? Staffs { get; set; }
    }
}
