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


        [HttpGet("{id}")]
        public IActionResult GetTeamCards(string id)
        {
            var isValidGuid = Guid.TryParse(id, out var guidId);
            if (!isValidGuid)
            {
                return BadRequest($"ID {id} is not a valid guid");
            }
            var team = _context.Teams.Include(x => x.Seasons).Include(x => x.Stadium).ThenInclude(x => x.Crimes).OrderByDescending(x => x.Name).FirstOrDefault(x => x.Id == guidId);
            if (team == null)
            {
                return NotFound($"Team with ID (${id}) could not be found");
            }
            return Ok(new TeamSummaryDTO(team));
        }
    }
}
