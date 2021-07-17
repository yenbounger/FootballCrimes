using FootballData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.Models
{
    public class Team : BaseEntity
    {
        private Team()
        {

        }
        public Team(RawTeam team, Season seasonToAdd)
        {
            Name = team.Name;
            CrestUrl = team.CrestUrl;
            Stadium = new Stadium(team.Venue, team.Address);
            ApiId = team.Id;
            Seasons.Add(seasonToAdd);
        }


        public string Name { get; private set; }
        public int ApiId { get; private set; }
        public string CrestUrl { get; private set; }
        // Seasons active in premier league
        // Would be a list of Stadium with more historical data, and would be changed as such if further developed
        // To allow for teams changing grounds
        public Stadium Stadium { get; private set; }
        public List<Season> Seasons { get; private set; } = new List<Season>();
        public string PostcodeToValidate { get; }

        public void AddSeason(Season season)
        {
            if (!Seasons.Contains(season))
            {
                Seasons.Add(season);
            }
            else
            {
                throw new Exception($"Team {Name} ({Id}) already contains season {season.StartDate}");
            }
        }
    }
}
