using Microsoft.EntityFrameworkCore;
using WebApplication10.Context;
using WebApplication10.Models;

namespace WebApplication10.Repository.Configuration
{
    public class CreditRepository : BaseRepository<Credit>
    {
        public CreditRepository(SchoolManagmentDB DbContext) : base(DbContext){ }
    }
}
