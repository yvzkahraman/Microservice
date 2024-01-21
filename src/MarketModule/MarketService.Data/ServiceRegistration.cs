using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MarketModule.MarketService.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddDbContext<MarketDbContext>(opt=>{
                opt.UseSqlServer("server=.; database=MicroserviceMarketDb; user id =sa; password=135135YK!; TrustServerCertificate=true;");
            });
        }
    }
}