using System.Linq.Expressions;

namespace WebApplication10.Repository.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public void Add(T Entity);
        public IEnumerable<T> GetAll();
        public T Get(int Id);
        public IEnumerable<T> Find(Expression<Func<T,bool>> Expression);
        public T SingleorDefault(Expression<Func<T,bool>> Expression);
        public void Update(T Entity);
        public void Remove(int Id);

    }
}
