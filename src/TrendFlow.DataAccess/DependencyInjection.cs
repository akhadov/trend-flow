using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrendFlow.DataAccess.Data;

namespace TrendFlow.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>();
        return services;
    }
}
