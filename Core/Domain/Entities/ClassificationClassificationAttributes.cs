using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassificationClassificationAttributes
    {
        public int ClassificationAttributeId { get; set; }

        public int ClassificationId { get; set; }

        public ClassificationAttribute ClassificationAttribute { get; set; }

        public Classification Classification { get; set; }
    }
}
