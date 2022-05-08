using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using ToolsManagement.Models;
using ToolsManagement.Services;

namespace ToolsManagement.Controllers
{
    [Route("api/endmillcutter")]
    [ApiController]
    public class EndMillCutterController : ControllerBase
    {
        private readonly IEndMillCutterService _endMillCutterService;

        public EndMillCutterController(IEndMillCutterService endMillCutterService)
        {
            _endMillCutterService = endMillCutterService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<EndMillCutterDto>> GetAll()
        {
            var endMillCutter = _endMillCutterService.GetAll();
            return Ok(endMillCutter);
        }
        [HttpGet("{id}")]
        public ActionResult<EndMillCutterDto> Get([FromRoute] int id)
        {
            var endMillCutter = _endMillCutterService.GetById(id);
            return endMillCutter;
        }
        [HttpPost]
        public ActionResult CreateEndMillCutter([FromBody] CreateEndMillCutterDto dto)
        {
            var id = _endMillCutterService.Create(dto);
            return Created($"/api/endmillcutter/{id}", null);
        }
    }
}
