using System.Collections.Generic;
using System.Linq;
using SP.Data.DataContext;
using SP.Data.Models;
using SP.Data.Repository.Interface;

namespace SP.Data.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly SpDataContext _spContext;
        public PersonRepository(SpDataContext context): base(context)
        {
            _spContext = context;
        }

        public IQueryable<Person> GetCustomPersons()
        {
            return _context.Person.AsQueryable();
        }
    }
}