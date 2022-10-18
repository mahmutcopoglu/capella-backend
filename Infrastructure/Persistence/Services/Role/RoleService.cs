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
        private readonly IRoleReadRepository _roleReadRepository;
        private readonly IRoleWriteRepository _roleWriteRepository;
        private readonly IPermissionReadRepository _permissionReadRepository;
        public RoleService(IRoleReadRepository roleReadRepository, IRoleWriteRepository roleWriteRepository, IPermissionReadRepository permissionReadRepository)
        {
            _roleReadRepository = roleReadRepository;
            _roleWriteRepository = roleWriteRepository;
            _permissionReadRepository = permissionReadRepository;
        }
    
        public async Task<bool> save(RoleDto roleDto)
        {
            Role role = new();
            role.Name = roleDto.Name;
            role.IsActive = roleDto.IsActive;
            var permissions = new HashSet<Domain.Entities.Permission>();
            foreach (var item in roleDto.Permissions)
            {
                var permission = _permissionReadRepository.GetWhere(x => x.Code == item.Code).FirstOrDefault();
                permissions.Add(permission);
            }
            role.Permissions = permissions;
            var result = await _roleWriteRepository.AddAsync(role);
            return result;
        }
    }
}
