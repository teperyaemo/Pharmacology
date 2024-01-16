using Drugs.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drugs.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<DrugsDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IDrugsDbContext>(provider => provider.GetService<DrugsDbContext>());
            return services;
        }
    }
}
