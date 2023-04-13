using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTreeAPI.Main.Dto.Build;
using TechTreeAPI.Main.IData;

namespace TechTreeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly IGeneralRepository generalRepository;

        public GeneralController(IGeneralRepository generalRepository)
        {
            this.generalRepository = generalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBuilds()
        {
            var result = await generalRepository.GetBuilds();
            return new JsonResult(result) { StatusCode = 200 };
        } 

        [HttpPost]
        public async Task<IActionResult> SetBuild([FromBody]BuildDto buildDto)
        {
            var result = await generalRepository.SetBuild(buildDto);
            if(result == null)
            {
                return new JsonResult("Error") { StatusCode = 404 };
            }
            else
            {
                return new JsonResult(result) { StatusCode = 200 };
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBuild(int id)
        {
            var result = await generalRepository.RemoveBuild(id);
            
            return new JsonResult(result) { StatusCode = 404 };
           
        }
    }
}
