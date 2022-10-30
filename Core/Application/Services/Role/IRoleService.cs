using Application.DataTransferObject;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IRoleService
    {
        Task<bool> save(RoleDto roleDto);

        Task<Role> getRoleById(int roleId);
    }
}
