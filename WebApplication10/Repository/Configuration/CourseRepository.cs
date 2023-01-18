using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository(SchoolManagmentDB DbContext) : base(DbContext){}

        public IEnumerable<Course> coursesWithoutTeacher() {
            return _dbSet.FromSqlRaw("Select * From Courses Where Id Not In(Select CourseId From TeacherEnrollements) ");
        }

    }
}
