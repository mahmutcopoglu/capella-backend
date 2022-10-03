using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public class ClassificationAttributeValueDto
    {
        public string Value { get; set; }
        public string ProductCode  { get; set; }
        public ClassificationAttributeDto ClassificationAttribute { get; set; }
    }
}
