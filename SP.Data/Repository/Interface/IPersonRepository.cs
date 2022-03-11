using System.Collections.Generic;
using System.Linq;
using SP.Data.Models;

namespace SP.Data.Repository.Interface
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        IQueryable<Person> GetCustomPersons();
    }
}