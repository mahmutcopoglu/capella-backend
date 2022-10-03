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

        public ClassificationAttributeValue()
        {
            Products = new List<Product>();
        }
        public string Code { get; set; }
        public string Value { get; set; }
        public ClassificationAttribute ClassificationAttribute { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
