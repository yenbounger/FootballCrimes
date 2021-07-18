using FootballCrimes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.DTO
{
    public class TeamCardDTO
    {
        public TeamCardDTO(Team team)
        {
            TeamId = team.Id;
            TeamName = team.Name;
            StadiumName = team.Stadium.Name;
            TeamCrestURL = team.CrestUrl;
            CrimeCount = team.Stadium.Crimes.Count;
            SeasonsInPremiership = team.Seasons.Select(x => x.StartDate.Year).ToList();
        }

        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public string StadiumName { get; set; }
        public string TeamCrestURL { get; set; }
        public int CrimeCount { get; set; }
        public List<int> SeasonsInPremiership { get; set; }
    }
}
