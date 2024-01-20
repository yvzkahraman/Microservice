using Microsoft.Extensions.DependencyInjection;
using UserModule.UserService.Data;

namespace UserModule.UserService.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddDataServices();
        }
    }
}