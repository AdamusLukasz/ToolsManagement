using Microsoft.AspNetCore.Mvc;
using ToolsManagement.Models.DrillParametersModels;
using ToolsManagement.Services.Interfaces;

namespace ToolsManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrillParametersController : ControllerBase
    {
        private readonly IDrillParametersService _drillParametersService;

        public DrillParametersController(IDrillParametersService drillParametersService)
        {
            _drillParametersService = drillParametersService;
        }
        [HttpPost("drill{drillId}/material{materialId}")]
        public ActionResult Post([FromRoute] int drillId, int materialId, [FromBody] CreateDrillParametersDto dto)
        {
            var newDrillParameterslId = _drillParametersService.CreateDrillParameters(drillId, materialId, dto);
            return Created($"api/drill/{drillId}/drill/{newDrillParameterslId}", null);
        }
    }
}
