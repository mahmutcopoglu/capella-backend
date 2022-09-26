using Application.Repositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly CapellaDbContext _context;

        public ReadRepository(CapellaDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhereWithInclude(Expression<Func<T, bool>> method, bool tracking = true,params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = Table;

            foreach(var item in include)
            {
                query = query.Include(item);
            }
            
            query = query.Where(method);

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public IQueryable<T> GetAllWithInclude(bool tracking = true, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = Table.AsQueryable();
            foreach (var item in include)
            {
                query = query.Include(item);
            }

            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
    }
}
