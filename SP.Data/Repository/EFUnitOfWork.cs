using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SP.Data.DataContext;
using SP.Data.Models;
using SP.Data.Repository.Interface;

namespace SP.Data.Repository
{
    public class EFUnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext, new()
    {
        private readonly TContext _context;

        private bool _disposed;
        private Hashtable _repositories;
        private IServiceScopeFactory _serviceScopeFactory;


        public EFUnitOfWork(TContext context, IServiceScopeFactory serviceScopeFactory)
        {
            _context = context;
            _serviceScopeFactory=serviceScopeFactory;
        }

        public TContext Context
        {
            get { return _context; }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            //todo: try register  service to container?

            return (IGenericRepository<T>)_repositories[type];
        }
    }
}