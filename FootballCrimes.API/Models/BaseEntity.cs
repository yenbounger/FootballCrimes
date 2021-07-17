using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            {
                if (Id == default)
                {
                    Id = Guid.NewGuid();
                }
                else
                {
                    // custom exception would be nice here
                    throw new Exception("Entity has already been assigned an ID");
                }
            }
        }
        public Guid Id { get; private set; }

    }
}
