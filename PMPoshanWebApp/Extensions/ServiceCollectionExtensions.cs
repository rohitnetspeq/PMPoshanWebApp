using Microsoft.Extensions.DependencyInjection;
using PMPoshanWebApp.Integrations.EMIS.Interfaces;
using PMPoshanWebApp.Integrations.EMIS.Services;

namespace PMPoshanWebApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEmisIntegration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IEmisApiClient, EmisApiClient>(client =>
            {
                client.BaseAddress = new Uri(configuration["EmisApi:BaseUrl"]);
            });

            return services;
        }
    }
}
