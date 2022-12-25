using CanfieldSchool.Models;

namespace CanfieldSchool.SchoolRepository
{
    public interface ICanfielSchool
    {

        IEnumerable<CanfiledStudent> GetStudents();
        CanfiledStudent GetStudentById(int id);
        IEnumerable<CanfiledStaff> GetStaffs();
        CanfiledStaff GetStaffById(int id);
        IEnumerable<CanfiledTeacher> GetTeachers();
        CanfiledTeacher GetTeachersById(int id);
        IEnumerable<CanfieldSchoolModel> GetSchoolsData();
        CanfiledTeacher AddTeacher(CanfiledTeacher reponse);

    }
}
