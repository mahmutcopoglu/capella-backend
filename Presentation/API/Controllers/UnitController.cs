using Application.DataTransferObject;
using Application.Repositories;
using Application.Repositories.ProductAbstract;
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
        private readonly IUnitReadRepository _unitReadRepository;
        private readonly IUnitWriteRepository _unitWriteRepository;
        private readonly IMapper _mapper;

        public UnitController(IUnitReadRepository unitReadRepository, IUnitWriteRepository unitWriteRepository, IMapper mapper)
        {
            _unitReadRepository = unitReadRepository;
            _unitWriteRepository = unitWriteRepository;
            _mapper = mapper;
        }

        [HttpPost("/unit")]
        public async Task<IActionResult> AddUnit([FromBody] UnitDto unitDto)
        {
            var unit = _mapper.Map<Unit>(unitDto);
            unit.Code = Guid.NewGuid().ToString();
            var result = await _unitWriteRepository.AddAsync(unit);
            if (!result)
            {
                return BadRequest();
            }
            else
            {
                return Ok(unit);
            }

        }
    }
}
