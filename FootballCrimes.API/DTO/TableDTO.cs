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
        public TableDTO(List<Crime> crime, int count)
        {
            CrimeData = crime.Select(x => new CrimeData(x)).ToList();
            Count = count;
        }
        public int Count { get; set; }
        public List<CrimeData> CrimeData { get; set; }
    }

    public class CrimeData
    {
        public CrimeData(Crime crime)
        {
            DateCommited = crime.Date;
            CrimeType = crime.Type;
            StadiumName = crime.Stadium.Name;
            TeamName = crime.Stadium.Team.Name;
            TeamId = crime.Stadium.TeamId;
        }


        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public string StadiumName { get; set; }
        public CrimeType CrimeType { get; set; }
        public DateTime DateCommited { get; set; }
    }

}
