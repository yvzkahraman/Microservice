using Microsoft.Extensions.DependencyInjection;
using UserModule.UserService.Business.Handlers;
using UserModule.UserService.Data;

namespace UserModule.UserService.Business
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<CreateUserCommandHandler>();
            services.AddScoped<GetUserListQueryHandler>();
            services.AddScoped<UpdateUserCommandHandler>();
            services.AddScoped<RemoveUserCommandHandler>();


            services.AddDataServices();
        }
    }
}