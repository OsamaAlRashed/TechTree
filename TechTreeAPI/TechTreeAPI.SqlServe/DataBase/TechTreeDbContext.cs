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
        public DbSet<Build> Builds { get; set; }

    }
}
