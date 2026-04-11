using TestingApp.Services;

namespace TestingApp.Common
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        { 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
