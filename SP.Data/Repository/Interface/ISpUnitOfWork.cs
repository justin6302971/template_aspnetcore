using System;
using Microsoft.EntityFrameworkCore;

namespace SP.Data.Repository.Interface
{
    /// <summary>
    /// handle repositories and saving mechanism
    /// </summary>
    public interface ISpUnitOfWork : IDisposable
    {
        void SaveChanges();

        IPersonRepository Persons { get; }
    }
}