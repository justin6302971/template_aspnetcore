using SP.Data.DataContext;
using SP.Data.Repository.Interface;

namespace SP.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SpDataContext _context;
        public GenericRepository(SpDataContext context){
                _context=context;
        }

        public void Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<T> GetAll()
        {
          return _context.Set<T>().AsQueryable();
        }

        public System.Linq.IQueryable<T> GetBy(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}