using System;
using System.Collections.Generic;
using System.Text;

namespace TechTreeAPI.Main.Dto.Build
{
    public class BuildDto
    {
        public int Id { get; set; }
        public string BuildName { get; set; }
        public int Cost { get; set; }
        public int MaxCount { get; set; }
    }
}
