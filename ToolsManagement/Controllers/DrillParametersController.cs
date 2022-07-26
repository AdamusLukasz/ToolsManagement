using Microsoft.AspNetCore.Mvc;
using ToolsManagement.Models.Drill;
using ToolsManagement.Services.Interfaces;

namespace ToolsManagement.Controllers
{
    [ApiController]
    [Route("api/drill{drillId}/drillParameters")]
    public class DrillParametersController : ControllerBase
    {
        private readonly IDrillParametersService _drillParametersService;

        public DrillParametersController(IDrillParametersService drillParametersService)
        {
            _drillParametersService = drillParametersService;
        }
        [HttpPost]
        public ActionResult Post([FromRoute] int drillId, [FromBody] CreateDrillParametersDto dto)
        {
            var newDrillId = _drillParametersService.CreateDrillParameters(drillId, dto);
            return Created($"api/toolsmanagement/{drillId}/drill/{newDrillId}", null);
        }
    }
}
