using Microsoft.Extensions.DependencyInjection;
using UserModule.UserService.Data.Interfaces;
using UserModule.UserService.Data.Repositories;

namespace UserModule.UserService.Data
{
    public static class DataRegistration
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}