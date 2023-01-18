using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class GradeRepository : BaseRepository<Grade>
    {
        public GradeRepository(SchoolManagmentDB DbContext) : base(DbContext) {}
    }
}
