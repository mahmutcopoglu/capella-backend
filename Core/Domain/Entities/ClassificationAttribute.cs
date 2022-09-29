using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassificationAttribute : BaseEntity
    {
        public Unit Units { get; set; }
        public ICollection<Classification> Classifications { get; set; }
    }
}
