using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; } 
        public bool IsActive { get; set; }  
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Role> Roles { get; set; }

    }
}
