using FootballCrimes.API.DTO;
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
    public class TeamsController : ControllerBase
    {
        private readonly FootballCrimesContext _context;

        public TeamsController(FootballCrimesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTeamCards()
        {
            return Ok(_context.Teams.Include(x => x.Seasons).Include(x => x.Stadium).ThenInclude(x => x.Crimes).OrderByDescending(x => x.Name).Select(x => new TeamCardDTO(x)).ToList());
        }
    }
}
