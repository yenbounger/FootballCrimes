using FootballCrimes.API.Extensions;
using FootballCrimes.API.Models.Enums;
using Police.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FootballCrimes.API.Models
{
    public class Crime: BaseEntity
    {
        private Crime()
        {

        }

        public Crime(RawPoliceData rawPoliceData)
        {
            Type = rawPoliceData.Category.ToCrimeType();
            Date = DateTime.Parse(rawPoliceData.Month);
        }
        public CrimeType Type { get; private set; }
        public DateTime Date { get; private set; }
        public Stadium Stadium { get; private set; }
    }
}
