using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }    
        public string Firstname { get; set; }   
        public string Lastname { get; set; }    
        public string PhoneNumber { get; set; }
        public string City { get; set; }    
        public string District { get; set; }    
        public string Neighbourhood { get; set; }
        public string FullAddress { get; set; } 
        public User User { get; set; }
    }
}
