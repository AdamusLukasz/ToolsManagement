using Microsoft.AspNetCore.Authorization;
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

        [HttpPut("return/{drillId}")]
        public ActionResult Update([FromRoute] int drillId)
        {
            _magazineService.ReturnToMagazine(drillId);
            return Ok();

        }

        [HttpPut("take/{drillId}")]
        public ActionResult TakeFromMagazine([FromRoute] int drillId)
        {
            _magazineService.TakeFromMagazine(drillId);
            return Ok();

        }
        [Authorize(Roles = "Admin")]
        [HttpPut("updatemagazine/{drillId}")]
        public ActionResult UpdateQuantityInMagazine([FromRoute] int drillId, [FromBody] DrillMagazineQuantityUpdateDto dto)
        {
            _magazineService.UpdateQuantityInMagazine(drillId, dto);
            return Ok();
        }
    }
}
