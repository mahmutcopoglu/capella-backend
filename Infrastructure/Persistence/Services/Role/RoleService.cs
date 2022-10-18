using Application.DataTransferObject;
using Application.Repositories;
using Application.Services.Role;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleReadRepository _readRepository;
        private readonly IRoleWriteRepository _roleWriteRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleReadRepository readRepository, IRoleWriteRepository roleWriteRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _roleWriteRepository = roleWriteRepository;
            _mapper = mapper;
        }
    
        public async Task<bool> save(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            var result = await _roleWriteRepository.AddAsync(role);
            return result;
        }
    }
}
