using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(SchoolManagmentDB DbContext) : base(DbContext){}
    }
}
