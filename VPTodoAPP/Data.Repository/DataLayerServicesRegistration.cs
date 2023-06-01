using Data.Repository.Entities;
using Data.Repository.Interfaces;
using Data.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Repository
{
    public static class DataLayerServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TodosDbConn"),
            //    m => m.MigrationsAssembly("Data.Repository"))
            //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddDbContext<TodoDbContext>(options => options.UseSqlite(m => m.MigrationsAssembly("Data.Repository"))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            //services.AddDbContext<TodoDbContext>(options => options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<IDataRepository<TodoEntity>, TodoRepository>();

            return services;
        }
    }
}
