using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SP.Data.DataContext;
using SP.Data.Repository.Interface;

namespace SP.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public SpDataContext _context { get; set; }
        // public GenericRepository(IUnitOfWork<SpDataContext> unitOfWork)
        //    : this(unitOfWork.Context)
        // {
        // }
        
        public GenericRepository(SpDataContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public System.Linq.IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }



        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("didn't pass entity");
            }

            try
            {
                _context.Update(entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(entity);
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.ToList();
        }
    }
}