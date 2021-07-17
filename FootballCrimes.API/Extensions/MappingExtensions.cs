using FootballCrimes.API.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.Extensions
{
    public static class MappingExtensions
    {
        /// <summary>
        /// Converts a string the Crime Type Enum, if the string is valid
        /// </summary>
        /// <param name="str">The string to parse</param>
        public static CrimeType ToCrimeType(this string str)
        {
            return str switch
            {
                "anti-social-behaviour" => CrimeType.AntiSocialBehaviour,
                "bicycle-theft" => CrimeType.BicycleTheft,
                "burglary" => CrimeType.Burglary,
                "criminal-damage-arson" => CrimeType.CriminalDamageAndArson,
                "drugs" => CrimeType.Drugs,
                "other-theft" => CrimeType.OtherTheft,
                "possession-of-weapons" => CrimeType.PossessionOfWeapons,
                "public-order" => CrimeType.PublicOrder,
                "robbery" => CrimeType.Robbery,
                "shoplifting" => CrimeType.Shoplifting,
                "theft-from-the-person" => CrimeType.TheftFromThePerson,
                "vehicle-crime" => CrimeType.VehicleCrime,
                "violent-crime" => CrimeType.ViolenceAndSexualOffences,
                "other-crime" => CrimeType.OtherCrime,
                _ => throw new ArgumentException($"Crime type currently not supported. Provided: {str}"),
            };
        }
    }
}
