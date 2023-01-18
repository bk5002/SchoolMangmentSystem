using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.DTO;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class AssignmentRepository : BaseRepository<Assignment>
    {
        private readonly DbContext _dbContext;
        public AssignmentRepository(SchoolManagmentDB DbContext) : base(DbContext)
        {
            _dbContext = DbContext;
        }

        public bool CreateAssignment(int TeacherId, Assignment assignment)
        {
            int FlowStatus = _dbContext.Database.ExecuteSqlRaw("Execute AddAssignment {0},{1},{2},{3},{4},{5},{6}", TeacherId, assignment.CourseId, assignment.Title, assignment.FileUrl, assignment.Instruction, assignment.TotalMarks, assignment.Deadline);
            if (FlowStatus > 0)
            {
                return true;
            }
            return false;
        }
        public bool SetMarks(int TeacherId, SetMarks setMarks)
        {
            int FlowStatus = _dbContext.Database.ExecuteSqlRaw("Execute SetMarksAndRemarks {0},{1},{2},{3},{4}", TeacherId, setMarks.AssignmentId, setMarks.AssignedId, setMarks.ObtainMarks, setMarks.Remarks);
            if (FlowStatus > 0)
            {
                return true;
            }
            return false;
        }
        public IEnumerable<Assignment> GetCourseAssignments(int TeacherId, int? CourseId)
        {

            return _dbSet.FromSqlRaw("Execute GetCourseAssignment {0},{1}", TeacherId, CourseId);
        }
    }
    
}