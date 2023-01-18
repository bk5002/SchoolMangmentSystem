using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.DTO;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class AssignedRepository:BaseRepository<Assigned>
    {
        private readonly SchoolManagmentDB _dbContext;
        public AssignedRepository(SchoolManagmentDB DbContext) : base(DbContext) {
            _dbContext = DbContext;
        }
        
        public IEnumerable<Assigned> GetMyAssignments(int studentId, int? CourseId) {
            return _dbSet.Include(a => a.Assignment).Where(a => a.StudentId == studentId && a.Assignment.CourseId == CourseId);
        }

        public bool SubmitAssignment(int StudentId, int AssignedId, string FileUrl, string CommentOrAnswer)
        {

            int FlowStatus = _dbContext.Database.ExecuteSqlRaw("Execute SubmitAssignment {0},{1},{2},{3}", StudentId, AssignedId,FileUrl,CommentOrAnswer);
            if (FlowStatus > 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<Assigned> GetStudentAssignments(int TeacherId, int? CourseId)
        {
            return _dbSet.FromSqlRaw("select * from GetMyStudentAssignments({0},{1})", TeacherId, CourseId).Include(a=>a.Student);
        }
        public int AssignedId(int studentId, int assignmentId) {
            var result = _dbSet.Where(a => a.AssignmentId == assignmentId && a.StudentId == studentId).FirstOrDefault();
            return result == null ? 0 : result.Id;
        }

        public int getCourseId(int? AssignedId) {
            return _dbSet.Include(a=>a.Assignment).Where(a=>a.Id == AssignedId).FirstOrDefault().Assignment.CourseId;
        }
        public string GetMyAssignmentUrl(int studentId, int assignmentId) {
            var result = _dbSet.Include(a=>a.Assignment).SingleOrDefault(a => a.StudentId == studentId && a.AssignmentId == assignmentId);
            return result==null?"":result.Assignment.FileUrl;
        }
    }

}
