using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApplication10.Context;
using WebApplication10.DTO;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class TeacherEnrollmentRepository:BaseRepository<TeacherEnrollement>
    {
        public TeacherEnrollmentRepository(SchoolManagmentDB DbContext) : base(DbContext) { }
        public IEnumerable<TeacherEnrollement> GetMyEnrolment(int Id)
        {

            return _dbSet.Include(e => e.Course).Where(e => e.UserId == Id);

        }
        public bool CheckUserAlreadyEnrolled(EnrollmentDTO enrollmentDTO)
        {

            return _dbSet.Where(e => e.UserId == enrollmentDTO.UserId && e.CourseId == enrollmentDTO.CourseId).FirstOrDefault() != null;

        }
        public int GetEnrollmentId(EnrollmentDTO enrollmentDTO)
        {
            var result =  _dbSet.Where(e => e.UserId == enrollmentDTO.UserId && e.CourseId == enrollmentDTO.CourseId).FirstOrDefault();
            return result == null ? 0 : result.Id;
        }
    }
}
