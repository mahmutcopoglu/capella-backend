using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public class RoleDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Permission> Permissions { get; set; }

    }
}
