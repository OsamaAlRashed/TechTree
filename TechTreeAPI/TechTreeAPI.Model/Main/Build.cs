using System;
using System.Collections.Generic;
using System.Text;
using TechTreeAPI.Model.Base;

namespace TechTreeAPI.Model.Main
{
    public class Build : EntityBase
    {
        public string BuildName { get; set; }
        public int Cost { get; set; }
        public int MaxCount { get; set; }
    }
}
