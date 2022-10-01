using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Unit : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
