using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTreeAPI.Base;
using TechTreeAPI.Main.Dto.Build;
using TechTreeAPI.Main.IData;
using TechTreeAPI.Model.Main;
using TechTreeAPI.SqlServe.DataBase;

namespace TechTreeAPI.Main.Data
{
    public class GeneralRepository : TreeTechRepository , IGeneralRepository
    {
        public GeneralRepository(TechTreeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<BuildDto>> GetBuilds()
        {
            try
            {
                var Builds = await Context.Builds.Select(build => new BuildDto
                {
                    Id = build.Id,
                    BuildName = build.BuildName,
                    MaxCount = build.MaxCount,
                    Cost = build.Cost
                }).ToListAsync();
                return Builds;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public async Task<bool> RemoveBuild(int id)
        {
            try
            {
                var build = await Context.Builds.Where(build => build.Id == id).SingleOrDefaultAsync();
                if (build == null)
                {
                    return false;
                }
                Context.Remove(build);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<BuildDto> SetBuild(BuildDto buildDto)
        {
            try
            {
                var build = await Context.Builds.Where(build => build.Id == buildDto.Id).SingleOrDefaultAsync();
                var entityState = EntityState.Modified;
                if (build == null)
                {
                    build = new Build();
                    entityState = EntityState.Added;
                }
                build.MaxCount = buildDto.MaxCount;
                build.Cost = buildDto.Cost;
                build.BuildName = buildDto.BuildName;

                Context.Entry(build).State = entityState;
                await Context.SaveChangesAsync();
                buildDto.Id = build.Id;
                return buildDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
