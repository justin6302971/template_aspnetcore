using System.Collections.Generic;
using System.Linq;
using SP.Data.Models;
using SP.Data.Repository.Interface;
using SP.Domain.DTO;

namespace SP.Services.PersonServices
{
    public class PersonService : IPersonService
    {
        private IUnitOfWork _unitOfWork;
        public PersonService(IUnitOfWork unitOfwork){

            _unitOfWork=unitOfwork;
        }

        public List<PersonDTO> GetAll()
        {
            var PersonRepo=_unitOfWork.Repository<Person>();
            var result=PersonRepo.GetAll().ToList()
                                        .Select(d=>new PersonDTO{
                                            Id=d.Id,
                                            LastName=d.LastName,
                                            FirstName=d.FirstName
                                        }).ToList();
            return result;
        }
    }
}