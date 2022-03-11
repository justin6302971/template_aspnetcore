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
        void Add(T entity);

        void Update(T entity);
        void Remove(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);


        #region async repository method 
        //implement by yourself if needed
        #endregion
    }
}