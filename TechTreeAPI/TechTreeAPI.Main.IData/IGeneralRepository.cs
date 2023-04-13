using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTreeAPI.Main.Dto.Build;

namespace TechTreeAPI.Main.IData
{
    public interface IGeneralRepository
    {
        public Task<IEnumerable<BuildDto>> GetBuilds();
        public Task<BuildDto> SetBuild(BuildDto buildDto);
        public Task<bool> RemoveBuild(int id);
    }
}
