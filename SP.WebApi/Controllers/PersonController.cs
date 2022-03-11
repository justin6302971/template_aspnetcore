

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SP.Data.DataContext;
using SP.Data.Models;
using SP.Data.Repository.Interface;
using SP.Domain.DTO;
using SP.Services.PersonServices;

namespace SP.WebApi.Controllers
{
    //demo controller
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private SpDataContext _db;

        private readonly ILogger<PersonController> _logger;
        private readonly IGenericRepository<Person> _personRepo;
        private readonly IPersonRepository _personCustomRepo;

        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger,
                                SpDataContext db,
                                IPersonRepository personCustomRepo,
                                IGenericRepository<Person> personRepo,
                                IPersonService personService
        )
        {
            _logger = logger;
            _db = db;
            _personRepo = personRepo;
            _personCustomRepo = personCustomRepo;
            _personService = personService;
        }

        //access from dbcontext
        [HttpGet("/v1/persons")]
        public List<PersonDTO> GetPersonFromDbContext()
        {
            return _db.Person.Select(d => new PersonDTO
            {
                Id = d.Id,
                LastName = d.LastName,
                FirstName = d.FirstName
            })
           .ToList();
        }

        //access from repository
        [HttpGet("/v2/persons")]
        public List<PersonDTO> GetPersonFromGeneralRepository()
        {
            return _personRepo.GetAll().Select(d => new PersonDTO
            {
                Id = d.Id,
                LastName = d.LastName,
                FirstName = d.FirstName
            })
            .ToList();
        }

        //access from repository
        [HttpGet("/v3/persons")]
        public List<PersonDTO> GetPersonFromCustomRepository()
        {
            return _personCustomRepo.GetAll().Select(d => new PersonDTO
            {
                Id = d.Id,
                LastName = d.LastName,
                FirstName = d.FirstName
            })
            .ToList();
        }

        //access from service with dbcontext
        [HttpGet("/v4/persons")]
        public List<PersonDTO> GetPersonFromServiceWithDbContext()
        {
            return _personService.GetAllWithDbContext();
        }

        //access from service with unit of work pattern(with generic repo)
        [HttpGet("/v5/persons")]
        public List<PersonDTO> GetPersonFromServiceWithGeneralRepo()
        {
            return _personService.GetAllWithGeneralRepo();
        }

        //access from service with unit of work pattern(with generic repo)
        [HttpGet("/v6/persons")]
        public List<PersonDTO> GetPersonFromServiceWithCustomRepo()
        {
            return _personService.GetAllWithCustomRepo();
        }
    }
}