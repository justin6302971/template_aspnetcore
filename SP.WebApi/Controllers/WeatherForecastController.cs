using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SP.Data.DataContext;
using SP.Data.Repository.Interface;
using SP.Domain.DTO;
using SP.Services.PersonServices;

namespace SP.WebApi.Controllers
{
  

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private  SpDataContext _db;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPersonService _personService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,SpDataContext db,IPersonService PersonService)
        {
            _logger = logger;
            _db=db;
            _personService=PersonService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("getperson")]
        public IAsyncEnumerable<PersonDTO> getperson()
        {
            return  _db.Person.Select(d=>new PersonDTO{
                Id=d.Id,
                LastName=d.LastName,
                FirstName=d.FirstName
            }).AsAsyncEnumerable();
        }

        [HttpGet("v2/getperson")]
        public List<PersonDTO> getpersonfromService()
        {
            return  _personService.GetAll();
        }
    
    }
}
