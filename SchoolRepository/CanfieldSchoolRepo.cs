using CanfieldSchool.Database_context;
using CanfieldSchool.Models;
using CanfieldSchool.SchoolRepository;

namespace CanfieldSchool.SchoolRepository
{
    public class CanfieldSchoolRepo : ICanfielSchool
    {
        private CanfieldDbContext _canfieldContext;

        public CanfieldSchoolRepo(CanfieldDbContext canfieldContext)
        {
            _canfieldContext = canfieldContext;
        }

        public IEnumerable<CanfieldSchoolModel> GetSchoolModels()
        {
            return _canfieldContext.CanfieldSchoolModels.ToList();
        }

        public IEnumerable<CanfieldSchoolModel> GetSchoolsData()
        {
            throw new NotImplementedException();
        }

        public CanfiledStaff GetStaffById(int id)
        {
            var canStaff = _canfieldContext.CanfiledStaffs.Where(x => x.Id == id).FirstOrDefault();
            return canStaff;
        }

        //FOR===STAFFS

        public IEnumerable<CanfiledStaff> GetStaffs()
        {
            return _canfieldContext.CanfiledStaffs.ToList();
        }

        //FOR===STUDENTS
        //public CanfiledStudent AddStudents(CanfiledStudent response)
        //{
        //  var addStudent =   _canfieldContext.CanfiledStudents.Add(response);
        //    _canfieldContext.SaveChanges();
        //    return response;
        //}
        public IEnumerable<CanfiledStudent> GetStudents()
        {
            return _canfieldContext.CanfiledStudents.ToList();
        }

        public CanfiledStudent GetStudentById(int id)
        {
            var studentByid = _canfieldContext.CanfiledStudents.Where(x => x.Id == id).FirstOrDefault();
            return studentByid;
        }


        //FOR===TEACHERS
        public IEnumerable<CanfiledTeacher> GetTeachers()
        {
            return _canfieldContext.CanfiledTeachers.ToList();

        }

        public CanfiledTeacher GetTeachersById(int id)
        {
            var getTeacherbyid = _canfieldContext.CanfiledTeachers.Where(x => x.Id == id).FirstOrDefault();
            return getTeacherbyid;
        }

        public CanfiledTeacher AddTeacher(CanfiledTeacher response)
        {
            var createTeacher = _canfieldContext.CanfiledTeachers.Add(response);
            _canfieldContext.SaveChanges();
            return response;
        }

        public CanfiledStaff AddStaff(CanfiledStaff staff)
        {
            var createStaff = _canfieldContext.CanfiledStaffs.Add(staff);
            _canfieldContext.SaveChanges();
            return staff;
        }
    }
}

   

