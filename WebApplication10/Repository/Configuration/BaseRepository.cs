using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using WebApplication10.Context;
using WebApplication10.Repository.IRepositories;

namespace WebApplication10.Repository.Configuration
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        public readonly DbSet<T> _dbSet;

        public BaseRepository(SchoolManagmentDB DbContext) {
            _dbContext = DbContext;
            _dbSet = DbContext.Set<T>();
        
        }
        public void Add(T Entity)
        {
            _dbSet.Add(Entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> Expression)
        {
            return _dbSet.Where(Expression);
        }
        public T Get(int Id)
        {
            return _dbSet.Find(Id);
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public void Remove(int Id)
        {
            T Entity = this.Get(Id);
            _dbSet.Remove(Entity);

        }

        public T SingleorDefault(Expression<Func<T, bool>> Expression)
        {
            return _dbSet.SingleOrDefault(Expression);
        }

        public void Update(T Entity)
        {
             _dbSet.Update(Entity);
        }
    }
}
