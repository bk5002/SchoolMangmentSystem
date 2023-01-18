using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.Models;
using WebApplication10.Repository.Configuration;

namespace WebApplication10.UnitOfWork.Configuration
{
    public class BaseUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        
        public BaseUnitOfWork(SchoolManagmentDB DbContext) {
            _dbContext = DbContext;           
            Course = new CourseRepository(DbContext);
            Credit = new CreditRepository(DbContext);
            StudentEnrollment = new StudentEnrollmentRepository(DbContext);
            TeacherEnrollment = new TeacherEnrollmentRepository(DbContext);
            Assignment = new AssignmentRepository(DbContext);
            Assigned = new AssignedRepository(DbContext);
            Role = new RoleRepository(DbContext);
            Grade = new GradeRepository(DbContext);
            User = new UserRepository(DbContext);
        }

        public CourseRepository Course { get; }

        public CreditRepository Credit { get; }

        public StudentEnrollmentRepository StudentEnrollment { get; }
        public TeacherEnrollmentRepository TeacherEnrollment { get; }
        public AssignmentRepository Assignment { get; }
        public AssignedRepository Assigned { get; }

        public GradeRepository Grade { get; }

        public RoleRepository Role { get; }

        public UserRepository User { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
