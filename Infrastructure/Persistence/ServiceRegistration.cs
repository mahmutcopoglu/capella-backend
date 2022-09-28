using Application.Repositories;
using Application.Repositories.ProductAbstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CapellaDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<IClassificationWriteRepository, ClassificationWriteRepository>();
            services.AddScoped<IClassificationReadRepository, ClassificationReadRepository>();
            services.AddScoped<IUnitReadRepository, UnitReadRepository>();
            services.AddScoped<IUnitWriteRepository, UnitWriteRepository>();
        }
    }
}
