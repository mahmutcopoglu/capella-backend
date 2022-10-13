using Application.DataTransferObject;
using Application.Repositories;
using Application.Repositories.ProductAbstract;
using Application.Services.Unit;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
       

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;   
        }

        [HttpPost("/unit")]
        public async Task<IActionResult> AddUnit([FromBody] UnitDto unitDto)
        {

            var result =await _unitService.saveUnit(unitDto);
            if (!result)
            {
                return BadRequest();
            }
            else
            {
                return Ok(true);
            }
        }
    }
}
