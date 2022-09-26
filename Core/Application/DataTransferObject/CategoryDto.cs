using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int? ParentCategoryId { get; set; }
       
    }
}
