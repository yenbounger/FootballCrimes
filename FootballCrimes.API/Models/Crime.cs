using FootballCrimes.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.Models
{
    public class Crime: BaseEntity
    {
        private Crime()
        {

        }
        public CrimeType Type { get; private set; }
        public int Month { get; private set; }
        public int Year { get; private set; }
    }
}
