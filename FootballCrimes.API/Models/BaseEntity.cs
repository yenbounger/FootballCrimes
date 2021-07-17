using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.Models
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
    }
}
