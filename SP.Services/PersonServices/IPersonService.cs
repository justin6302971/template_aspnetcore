using System.Collections.Generic;
using SP.Domain.DTO;

namespace SP.Services.PersonServices
{
    public interface IPersonService
    {
       List<PersonDTO> GetAllWithDbContext();

       List<PersonDTO> GetAllWithGeneralRepo();

       List<PersonDTO> GetAllWithCustomRepo();

         
    }
}