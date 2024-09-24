using My_1_w.Application.Core.Interfaces;
//using My_1_w.ApplicationCore.Interfaces;
using My_1_w.infrastructure;
using NuGet.Common;

namespace My_1_w.Configuration
{
    public static class ConfigureCoreServices
    {
       internal static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
