using CanfieldSchool.Models;
using CanfieldSchool.SchoolRepository;
using Microsoft.AspNetCore.Mvc;

namespace CanfieldSchool.Controllers
{
    [ApiController]
    public class CanfieldSchoolController : Controller
    {
        private readonly ICanfielSchool _canfieldschoolrepository;

        public CanfieldSchoolController(ICanfielSchool canfieldschoolrepository)
        {
            _canfieldschoolrepository = canfieldschoolrepository;
        }

        [HttpGet("Students")]
        public IActionResult Students()
        {
            var students = _canfieldschoolrepository.GetStudents().ToList();
            return Ok(students);
        }

        [HttpGet("GetStudentById")]
        public IActionResult GetStudentById(int id)
        {
            var studentsid = _canfieldschoolrepository.GetStudentById(id);
            return Ok(studentsid);
        }

        [HttpGet("Staff")]
        public IActionResult Staff()
        {
            var staffs = _canfieldschoolrepository.GetStaffs();
            return Ok(staffs);

        }

        [HttpPost("StaffById")]
        public IActionResult GetStaffById(int id)
        {
            var staffsid = _canfieldschoolrepository.GetStaffById(id);
            return Ok(staffsid);
        }

        [HttpGet("Teachers")]
        public IActionResult Teachers()
        {
            var teachers = _canfieldschoolrepository.GetTeachers();
            return Ok(teachers);
        }
        [HttpPost("AddTeacher")]
        public IActionResult createTeacher(CanfiledTeacher response)
        {
            var teachers = _canfieldschoolrepository.AddTeacher(response);
            return Ok(teachers);
        }

    }
}
