using FindNumbersDivider.Application;
using FindNumbersDivider.Application.Interfaces;
using FindNumbersDivider.Domain.Services;
using FindNumbersDivider.Domain.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FindNumbersDivider.Ioc
{
    public static class Ioc
    {
        public static IServiceCollection SolveDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<INumberService, NumberService>()
                .AddScoped<IFindNumbersDividerAppService, FindNumbersDividerAppService>();
        }
    }
}