using CanfieldSchool.Models;

namespace CanfieldSchool.SchoolRepository
{
    public interface ICanfielSchool
    {
        //Crud operations for students
        IEnumerable<CanfiledStudent> GetStudents();
        CanfiledStudent GetStudentById(int id);
       // CanfiledStudent AddStudent(CanfiledStudent canfiledStudent);

        //Crud operation for Staff of schools
        IEnumerable<CanfiledStaff> GetStaffs();
        CanfiledStaff GetStaffById(int id);
        CanfiledStaff AddStaff(CanfiledStaff canfiledStaff);

        //Crud operations for teacher
        IEnumerable<CanfiledTeacher> GetTeachers();
        CanfiledTeacher GetTeachersById(int id);
        IEnumerable<CanfieldSchoolModel> GetSchoolsData();
        CanfiledTeacher AddTeacher(CanfiledTeacher reponse);

    }
}
