using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using ToolsManagement.Entities;
using ToolsManagement.Models.Drill;
using ToolsManagement.Models;
using ToolsManagement.Services.Interfaces;

namespace ToolsManagement.Controllers
{
    [Route("api/toolsmanagement/")]
    [ApiController]
    public class DrillController : ControllerBase
    {
        private readonly IDrillService _drillService;

        public DrillController(IDrillService drillService)
        {
            _drillService = drillService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<DrillDto>> GetAll()
        {
            var drills = _drillService.GetAll();
            return Ok(drills);
        }

        [HttpGet("{id}")]
        public ActionResult<DrillDto> Get([FromRoute] int id)
        {
            var drill = _drillService.GetById(id);
            return drill;
        }

        [HttpGet("getbydiameters")]
        public ActionResult<IEnumerable<DrillDto>> GetByDeclaredDiameters([FromQuery]int minDiameter, int maxDiameter)
        {
            var drills = _drillService.GetDrillForDeclaredDiameters(minDiameter, maxDiameter);
            return Ok(drills);
        }

        [HttpPost]
        public ActionResult CreateDrill([FromBody] CreateDrillDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _drillService.CreateDrill(dto);
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
