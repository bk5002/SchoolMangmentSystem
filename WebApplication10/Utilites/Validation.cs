using Microsoft.EntityFrameworkCore;
using WebApplication10.DTO;
using WebApplication10.Models;
using WebApplication10.UnitOfWork;

namespace WebApplication10.Utilites
{
    public class Validation
    {
        public static StudentEnrollment ValidTeacher(IUnitOfWork unitOfWork,int EnrollmentId)
        {
            var student = unitOfWork.StudentEnrollment.Get(EnrollmentId);
            return unitOfWork.TeacherEnrollment.SingleorDefault(t => t.CourseId == student.CourseId) == null ? null : student;



        }
    }
}
