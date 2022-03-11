using System.Collections.Generic;
using System.Linq;
using SP.Data.DataContext;
using SP.Data.Models;
using SP.Data.Repository.Interface;
using SP.Domain.DTO;

namespace SP.Services.PersonServices
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork<SpDataContext> _spUnitOfWork;
        private ISpUnitOfWork _spUnitOfWorkNew;
        private SpDataContext _db;

        public PersonService(
                IUnitOfWork<SpDataContext> spUnitOfWork,
                ISpUnitOfWork spUnitOfWorkNew,
                SpDataContext db)
        {
            _spUnitOfWork = spUnitOfWork;
            _spUnitOfWorkNew = spUnitOfWorkNew;
            _db = db;
        }


        public List<PersonDTO> GetAllWithDbContext()
        {
            return _db.Person.Select(d => new PersonDTO
            {
                Id = d.Id,
                LastName = d.LastName,
                FirstName = d.FirstName
            }).ToList();
        }

        public List<PersonDTO> GetAllWithGeneralRepo()
        {
            var personRepo = _spUnitOfWork.Repository<Person>();
            var result = personRepo.GetAll()
                               .Select(d => new PersonDTO
                               {
                                   Id = d.Id,
                                   LastName = d.LastName,
                                   FirstName = d.FirstName
                               })
                                .ToList();
            return result;
        }

        public List<PersonDTO> GetAllWithCustomRepo()
        {
            return _spUnitOfWorkNew.Persons.GetCustomPersons().Select(d => new PersonDTO
            {
                Id = d.Id,
                LastName = d.LastName,
                FirstName = d.FirstName
            })
            .ToList();
        }

    }
}