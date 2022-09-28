using Application.Repositories;
using Application.Repositories.ProductAbstract;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitReadRepository : ReadRepository<Unit>, IUnitReadRepository
    {
        public UnitReadRepository(CapellaDbContext context) : base(context)
        {

        }
    }
}
