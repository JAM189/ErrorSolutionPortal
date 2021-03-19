using ErrorSolutionPortal.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorSolutionPortal.Application
{
    public static class AppBootstrapper
    {
        public static void ConfigApplicationDependency(
            this IServiceCollection services) 
        {
            services.AddScoped<IErrorAppService,ErrorAppService>();
            services.ConfigCoreDependency();
        }
        public static void ConfigCoreDependency(this IServiceCollection services)
        {       
            services.AddScoped<IErrorManager, ErrorManager>();
        }
    }
}

