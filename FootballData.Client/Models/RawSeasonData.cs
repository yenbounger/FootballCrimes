using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballData.Client
{
    public class Filters
    {
    }

    public class RawArea
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class RawCompetition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("area")]
        public RawArea Area { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("plan")]
        public string Plan { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }

    public class RawSeason
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; }

        [JsonPropertyName("currentMatchday")]
        public int CurrentMatchday { get; set; }

        [JsonPropertyName("winner")]
        public object Winner { get; set; }
    }

    public class RawTeam
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("area")]
        public RawArea Area { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("tla")]
        public string Tla { get; set; }

        [JsonPropertyName("crestUrl")]
        public string CrestUrl { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("founded")]
        public int? Founded { get; set; }

        [JsonPropertyName("clubColors")]
        public string ClubColors { get; set; }

        [JsonPropertyName("venue")]
        public string Venue { get; set; }

        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }

    public class RawSeasonData
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("filters")]
        public Filters Filters { get; set; }

        [JsonPropertyName("competition")]
        public RawCompetition Competition { get; set; }

        [JsonPropertyName("season")]
        public RawSeason Season { get; set; }

        [JsonPropertyName("teams")]
        public List<RawTeam> Teams { get; set; }
    }




}
