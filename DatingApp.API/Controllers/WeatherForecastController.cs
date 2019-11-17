using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
        }

    }
}
