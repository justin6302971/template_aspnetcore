using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SP.Data.Repository.Interface
{
    /// <summary>
    /// define repository methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);
        void Remove(T entity);

        void SaveChanges();

        #region async repository method 

        #endregion
    }
}