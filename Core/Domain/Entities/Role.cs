using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }    
        public bool IsActive { get; set; }  
        public User User { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    
        
    }
}
