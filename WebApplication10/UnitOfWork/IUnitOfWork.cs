using WebApplication10.Models;
using WebApplication10.Repository.Configuration;

namespace WebApplication10.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public CourseRepository Course { get; }
        public CreditRepository Credit { get; }
        public StudentEnrollmentRepository StudentEnrollment { get; }
        public TeacherEnrollmentRepository TeacherEnrollment { get; }
        public AssignmentRepository Assignment { get; }
        public AssignedRepository Assigned { get; }
        public GradeRepository Grade { get; }
        public RoleRepository Role { get; }
        public UserRepository User { get; }
        public int SaveChanges();

    }
}
