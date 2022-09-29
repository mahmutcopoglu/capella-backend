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
        public string Code { get; set; }
        public string Value { get; set; }  
        public Product Product { get; set; }   
        public ClassificationAttribute ClassificationAttribute{ get; set; }    
    }
}
