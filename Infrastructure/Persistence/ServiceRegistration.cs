using Application.Repositories;
using Application.Repositories.ProductAbstract;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Services;
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
            #region Connection String
            services.AddDbContext<CapellaDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            #endregion

            #region Repository Registration
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<IClassificationWriteRepository, ClassificationWriteRepository>();
            services.AddScoped<IClassificationReadRepository, ClassificationReadRepository>();
            services.AddScoped<IUnitReadRepository, UnitReadRepository>();
            services.AddScoped<IUnitWriteRepository, UnitWriteRepository>();
            services.AddScoped<IClassificationAttributeReadRepository, ClassificationAttributeReadRepository>();
            services.AddScoped<IClassificationAttributeWriteRepository, ClassificationAttributeWriteRepository>();  
            services.AddScoped<IClassificationAttributeValueReadRepository, ClassificationAttributeValueReadRepository>();  
            services.AddScoped<IClassificationAttributeValueWriteRepository, ClassificationAttributeValueWriteRepository>();
            #endregion

            #region Service Registration
            services.AddScoped<IClassificationService, ClassificationService>();
            #endregion
        }
    }
}
