using FootballCrimes.API.Models;
using FootballCrimes.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.DTO
{
    public class TableDTO
    {
        public TableDTO(Team team)
        {
            TeamId = team.Id;
            TeamCrestUrl = team.CrestUrl;
            TeamName = team.Name;
            StadiumName = team.Stadium.Name;
            Crimes = team.Stadium.Crimes.Select(x => new CrimeDTO(x)).ToList();
        }
        public Guid TeamId { get; set; }
        public string TeamCrestUrl { get; set; }
        public string TeamName { get; set; }
        public string StadiumName { get; set; }
        public List<CrimeDTO> Crimes { get; set; }
    }

    public class CrimeDTO
    {
        public CrimeDTO(Crime crime)
        {
            CrimeType = crime.Type;
            DateCommited = crime.Date;
        }
        public CrimeType CrimeType { get; set; }
        public DateTime DateCommited { get; set; }
    }
}
