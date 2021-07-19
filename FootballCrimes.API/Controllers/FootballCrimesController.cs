using FootballCrimes.API.DTO;
using FootballCrimes.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballCrimesController : ControllerBase
    {
        private readonly FootballCrimesContext _context;

        public FootballCrimesController(FootballCrimesContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TableDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTableData([FromQuery] int page = 0, [FromQuery] int take = 10, [FromQuery] string sortDirection = "desc")
        {
            var count = _context.Crimes.Count();
            List<Crime> allCrimes;
            if (sortDirection == "asc")
            {
                allCrimes = _context.Crimes.Include(x => x.Stadium).ThenInclude(x => x.Team).OrderBy(x => x.Date).Skip(page * take).Take(take).ToList();
            }
            else if (sortDirection == "desc")
            {
                allCrimes = _context.Crimes.Include(x => x.Stadium).ThenInclude(x => x.Team).OrderByDescending(x => x.Date).Skip(page * take).Take(take).ToList();
            }
            else
            {
                return BadRequest($"{sortDirection} is not a valid sort direction");
            }
            return Ok(new TableDTO(allCrimes, count));
        }

    }
}
