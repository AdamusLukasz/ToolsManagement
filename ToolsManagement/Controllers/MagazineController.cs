using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsManagement.Models.Drill;
using ToolsManagement.Services;

namespace ToolsManagement.Controllers
{
    [Route("api/magazine")]
    [ApiController]
    public class MagazineController : ControllerBase
    {
        private readonly IMagazineService _magazineService;

        public MagazineController(IMagazineService magazineService)
        {
            _magazineService = magazineService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DrillDto>> GetAll()
        {
            var drills = _magazineService.GetAll();
            return Ok(drills);
        }
    }
}
