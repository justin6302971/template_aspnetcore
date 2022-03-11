using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using SP.Data.DataContext;
using SP.Data.Models;
using SP.Data.Repository.Interface;

namespace SP.Data.Repository
{
    public class SpEFUnitOfWork : ISpUnitOfWork, IDisposable
    {
        private readonly SpDataContext _spContext;
        // private readonly PersonRepository _personRepository;

        private bool _disposed;

        public IPersonRepository Persons { get; }

        public SpEFUnitOfWork(
               SpDataContext spContext,
               IPersonRepository personRepository)
        {
            _spContext = spContext;
            // Persons = new PersonRepository(spContext);
            Persons = personRepository;

        }

        public void SaveChanges()
        {
            _spContext.SaveChanges();
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
                    _spContext.Dispose();
                }
            }

            _disposed = true;
        }
    }
}