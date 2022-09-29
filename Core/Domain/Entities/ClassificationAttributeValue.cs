using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassificationAttributeValue : BaseEntity
    {
        public int Value { get; set; }  
        public Product Products { get; set; }   
        public ICollection<ClassificationAttribute> ClassificationAttributes{ get; set; }    
    }
}
