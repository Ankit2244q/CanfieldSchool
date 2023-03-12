using Microsoft.EntityFrameworkCore;
using CanfieldSchool.Models;
using Microsoft.Win32;
using CanfieldSchool.Login_Register;

namespace CanfieldSchool.Database_context
{
    public class CanfieldDbContext : DbContext
    {
        public CanfieldDbContext(DbContextOptions<CanfieldDbContext> options) : base(options)
        {

        }

        ////public RegisterDbContext(DbContextOptions<RegisterDbContext> options)
        //   : base(options)
        //{
        //}
        //public DbSet<Register> Register { get; set; }
        //public DbSet<UserLogin> Login { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //    base.OnConfiguring(optionsBuilder);

        //    //services.AddDbContext<dbsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("DefaultConnection");
        //        base.OnConfiguring(optionsBuilder);
                
        //    }

        //}

        public DbSet<CanfieldSchoolModel> CanfieldSchoolModels { get; set; }

        public DbSet<CanfiledStaff> CanfiledStaffs { get; set; }

        public DbSet<CanfiledStudent> CanfiledStudents { get; set; }

        public DbSet<CanfiledTeacher> CanfiledTeachers { get; set; }

        public DbSet<UserLogin>  users { get; set; }
    }
}
            