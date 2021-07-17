using FootballData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.Models
{
    public class Season: BaseEntity
    {
        private Season()
        {

        }
        public Season(RawSeasonData rawSeasonData)
        {
            StartDate = DateTime.Parse(rawSeasonData.Season.StartDate);
            EndDate = DateTime.Parse(rawSeasonData.Season.EndDate);
        }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<Team> Teams { get; private set; }
    }
}
