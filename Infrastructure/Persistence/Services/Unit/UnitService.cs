using Application.DataTransferObject;
using Application.Repositories;
using Application.Services.Unit;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class UnitService : IUnitService
    {
        private readonly IUnitReadRepository _unitReadRepository;
        private readonly IUnitWriteRepository _unitWriteRepository;
        private readonly IMapper _mapper;

        public UnitService(IUnitReadRepository unitReadRepository, IUnitWriteRepository unitWriteRepository, IMapper mapper)
        {
            _unitReadRepository = unitReadRepository;
            _unitWriteRepository = unitWriteRepository;
            _mapper = mapper;
        }

        
        public async Task<bool> saveUnit(UnitDto unitDto)
        {
            var unit = _mapper.Map<Unit>(unitDto);
            var result = await _unitWriteRepository.AddAsync(unit);
            if (!result)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}
