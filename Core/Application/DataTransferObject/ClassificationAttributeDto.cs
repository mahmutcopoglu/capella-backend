using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public class ClassificationAttributeDto
    {
        public string Code { get; set; }
        public UnitDto? Unit { get; set; }
    }
}
