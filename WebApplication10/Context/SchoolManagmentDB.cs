using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Context
{
    public class SchoolManagmentDB:DbContext
    {
        public SchoolManagmentDB(DbContextOptions<SchoolManagmentDB> options) : base(options) {}
        public DbSet<Course> Courses { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<StudentEnrollment> StudentsEnrollments { get; set; }
        public DbSet<TeacherEnrollement> TeacherEnrollements{ get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> UserRoles { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Assigned> Assigneds { get; set; }
        public DbSet<StoreProcedureResult> StoreProcedureResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }

    
}
