using System;
using System.Collections.Generic;
using System.Text;
using TechTreeAPI.SqlServe.DataBase;

namespace TechTreeAPI.Base
{
    public class TreeTechRepository
    {
        protected TreeTechRepository(TechTreeDbContext context)
        {
            Context = context;
        }
        protected TechTreeDbContext Context { get; set; }
    }
}
