using Application.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ClassificationAttributeReadRepository : ReadRepository<ClassificationAttribute> , IClassificationAttributeReadRepository
    {
        public ClassificationAttributeReadRepository(CapellaDbContext context) : base(context)  
        {

        }
    }
}
