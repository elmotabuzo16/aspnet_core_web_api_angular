using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(DataContext context, ILogger<WeatherForecastController> logger)
        {
            this._context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetValues()
        {
            var values = _context.Values.ToList();

            return Ok(values);
        }


        [HttpGet("{id}")]
        public IActionResult GetValues(int id)
        {
            var value = _context.Values.FirstOrDefault(x => x.Id == id);

            return Ok(value);
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        

        
    }
}
