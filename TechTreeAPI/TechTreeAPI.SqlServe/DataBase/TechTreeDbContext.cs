using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechTreeAPI.Model.Main;

namespace TechTreeAPI.SqlServe.DataBase
{
    public class TechTreeDbContext:DbContext
    {
        public TechTreeDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Build>()
                .HasData(
                    new Build() { Id = 1, BuildName = "CommandCenter", Cost = 1000, MaxCount = 1 },
                    new Build() { Id = 2, BuildName = "Power", Cost = 1200, MaxCount = 2 },
                    new Build() { Id = 3, BuildName = "Barracks", Cost = 1300, MaxCount = 1 },
                    new Build() { Id = 4, BuildName = "Defences", Cost = 1100, MaxCount = 3 },
                    new Build() { Id = 5, BuildName = "Mine", Cost = 1500, MaxCount = 2 },
                    new Build() { Id = 6, BuildName = "Airport", Cost = 2000, MaxCount = 2 },
                    new Build() { Id = 7, BuildName = "WarFactory", Cost = 1500, MaxCount = 3 },
                    new Build() { Id = 8, BuildName = "StrategyCenter", Cost = 1700, MaxCount = 1 },
                    new Build() { Id = 9, BuildName = "Hospital", Cost = 2500, MaxCount = 1 },
                    new Build() { Id = 10, BuildName = "Radar", Cost = 900, MaxCount = 10 },
                    new Build() { Id = 11, BuildName = "NuclearPower", Cost = 4000, MaxCount = 1 },
                    new Build() { Id = 12, BuildName = "SuperWeapon", Cost = 2500, MaxCount = 1 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Build> Builds { get; set; }

    }
}
