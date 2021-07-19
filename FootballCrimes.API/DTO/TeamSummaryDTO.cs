using FootballCrimes.API.Models;
using FootballCrimes.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.DTO
{
    public class TeamSummaryDTO : TeamCardDTO
    {
        public TeamSummaryDTO(Team team) : base(team)
        {
            StadiumAddress = team.Stadium.FullAddress;
            StadiumLat = team.Stadium.Latitude;
            StadiumLng = team.Stadium.Longitude;
            TeamCrimes = team.Stadium.Crimes.Select(x => new TeamCrimesDto(x)).ToList();
        }

        public string StadiumAddress { get; set; }
        public double StadiumLat { get; set; }
        public double StadiumLng { get; set; }
        public List<TeamCrimesDto> TeamCrimes { get; set; }
    }

    public class TeamCrimesDto
    {
        public TeamCrimesDto(Crime crime)
        {
            CrimeType = crime.Type;
            DateCommited = crime.Date;

        }
        public CrimeType CrimeType { get; set; }
        public DateTime DateCommited { get; set; }
    }
}
