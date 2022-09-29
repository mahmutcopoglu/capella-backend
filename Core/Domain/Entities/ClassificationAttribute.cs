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
        public string Code { get; set; }
        public Unit? Unit { get; set; }
        public Classification? Classification { get; set; }
    }
}
