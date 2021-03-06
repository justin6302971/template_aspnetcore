using Microsoft.EntityFrameworkCore;

namespace SP.Data.Repository.Interface
{
    /// <summary>
    /// handle repositories and saving mechanism
    /// </summary>
    public interface IUnitOfWork<TContext> where TContext : DbContext, new()
    {
        TContext Context { get; }
        void SaveChanges();

        IGenericRepository<T> Repository<T>() where T : class;
    }
}