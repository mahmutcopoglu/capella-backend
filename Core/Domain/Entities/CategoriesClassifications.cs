using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoriesClassifications
    {
        public int CategoryId { get; set; }

        public int ClassificationId { get; set; }

        public Category? Category { get; set; }

        public Classification? Classification { get; set; }

        
    }
}
