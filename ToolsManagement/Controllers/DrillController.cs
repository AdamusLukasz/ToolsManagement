using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using ToolsManagement.Entities;
using ToolsManagement.Models.DrillModel;
using ToolsManagement.Models;
using ToolsManagement.Services.Interfaces;
using ToolsManagement.Data.Entities;
using System.Threading.Tasks;

namespace ToolsManagement.Controllers
{
    [Route("api/toolsmanagement/drills")]
    [ApiController]
    public class DrillController : ControllerBase
    {
        private readonly IDrillService _drillService;

        public DrillController(IDrillService drillService)
        {
            _drillService = drillService;
        }

        [HttpGet("paginated")]
        public ActionResult<PagedResult<DrillDto>> GetAll([FromQuery] DrillQuery drillQuery)
        {
            var drills = _drillService.GetPaginated(drillQuery);
            return Ok(drills);
        }

        [HttpGet]
        public async Task<ActionResult<DrillDto>> GetAllAsync()
        {
            var drills = await _drillService.GetAllAsync();
            return Ok(drills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrillDto>> Get([FromRoute] int id)
        {
            var drill = await _drillService.GetByIdAsync(id);
            return drill;
        }

        [HttpGet("getbydiameters")]
        public async Task<ActionResult<IEnumerable<DrillDto>>> GetByDeclaredDiameters([FromQuery]int minDiameter, int maxDiameter)
        {
            var drills = await _drillService.GetDrillForDeclaredDiametersAsync(minDiameter, maxDiameter);
            return Ok(drills);
        }

        [HttpPost]
        public ActionResult CreateDrill([FromBody] CreateDrillDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _drillService.CreateDrillAsync(dto);
            return Created($"/api/toolsmanagement/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _drillService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateDrillDto dto, [FromRoute] int id)
        {
            _drillService.Update(id, dto);
            return Ok();
        }
    }
}
