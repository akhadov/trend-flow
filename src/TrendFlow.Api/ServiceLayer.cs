using TrendFlow.Application.Services.Contracts;
using TrendFlow.Application.Services.Implementations;

namespace TrendFlow.Api
{
    public static class ServiceLayerConfiguration
    {
        public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IBrandService, BrandService>();
        }
    }
}
