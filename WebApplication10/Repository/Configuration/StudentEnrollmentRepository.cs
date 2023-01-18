using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.DTO;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class StudentEnrollmentRepository : BaseRepository<StudentEnrollment>
    {
        public StudentEnrollmentRepository(SchoolManagmentDB DbContext) : base(DbContext){ }
        public IEnumerable<StudentEnrollment> GetMyEnrolment(int Id)
        {

            return _dbSet.Include(e => e.Course).Where(e => e.UserId == Id);

        }
        public bool CheckUserAlreadyEnrolled(EnrollmentDTO enrollmentDTO) {
            
            return _dbSet.Where(e => e.UserId == enrollmentDTO.UserId && e.CourseId == enrollmentDTO.CourseId).FirstOrDefault()!=null;
        
        }
    }
}
