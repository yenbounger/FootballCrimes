using FootballCrimes.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballCrimes.API
{
    public class FootballCrimesContext : DbContext
    {
        public FootballCrimesContext(DbContextOptions<FootballCrimesContext> opts) : base(opts)
        {

        }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Crime> Crimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(team => {
                team.HasOne(x => x.Stadium).WithOne(x => x.Team).HasForeignKey<Stadium>(x => x.TeamId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
