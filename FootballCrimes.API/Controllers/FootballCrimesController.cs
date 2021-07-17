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
    public class FootballCrimesController : ControllerBase
    {
        private readonly FootballCrimesContext _context;

        public FootballCrimesController(FootballCrimesContext context)
        {
            _context = context;
        }

       [HttpGet]
       public List<TableDTO> GetTableData()
        {
            var allCrimes = _context.Teams.Include(x => x.Stadium).ThenInclude(x => x.Crimes).ToList();
            return allCrimes.Select(x => new TableDTO(x)).ToList();
        }

    }
}
