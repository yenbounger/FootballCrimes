using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.Models
{
    public class Stadium: BaseEntity
    {
        private Stadium()
        {

        }
        public Stadium(string venue, string address)
        {
            Name = venue;
            FullAddress = address;
        }

        public string Name { get; private set; }
        public string FullAddress { get; private set; }
        public string PostcodeToValidate { get
            {
                var split = FullAddress.Split(' ');
                // postcode is the last for address on the api can manipulate the string to get the post code
                return  $"{split[split.Length - 1]} {split[split.Length - 2]}";
            } }
        public string ValidatedPostcode { get; private set; }
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }
        public List<Crime> Crimes { get; private set; } = new List<Crime>();

        private void AddValidatedPostcode(string postcode)
        {
            if (ValidatedPostcode != default)
            {
                ValidatedPostcode = postcode;
            } else
            {
                throw new Exception($"Stadium {Name} ({Id}) already has a valid postcode.");
            }
        }

    }
}
