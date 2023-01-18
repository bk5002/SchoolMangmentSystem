using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.DTO;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class UserRepository : BaseRepository<User>
    {

        public UserRepository(SchoolManagmentDB DbContext) : base(DbContext) { }

        public IEnumerable<User> GetOnly(int RoleId) {

            return _dbSet.Include(u => u.Role).Where(u=>u.Role.Id==RoleId);
            
        }
        public User Login(string email, string pass)
        {
            return _dbSet.Include(u=>u.Role).FirstOrDefault(u=>email==u.Email && u.Password==pass);

        }

    }
}
