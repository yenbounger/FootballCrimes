using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Police.Client.Model
{
    public class Street
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("street")]
        public Street Street { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }

    public class OutcomeStatus
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }
    }

    public class RawPoliceData
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("outcome_status")]
        public OutcomeStatus OutcomeStatus { get; set; }

        [JsonPropertyName("persistent_id")]
        public string PersistentId { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("location_subtype")]
        public string LocationSubtype { get; set; }

        [JsonPropertyName("month")]
        public string Month { get; set; }
    }
}
