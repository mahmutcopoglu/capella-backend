using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);

        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);

        Task<T> GetByIdAsync(int id, bool tracking = true);

        IQueryable<T> GetWhereWithInclude(Expression<Func<T, bool>> method, bool tracking = true, params Expression<Func<T, object>>[] include);

        IQueryable<T> GetAllWithInclude(bool tracking = true, params Expression<Func<T, object>>[] include);
    }
}
