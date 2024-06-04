using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrendFlow.DataAccess.Data;
using TrendFlow.DataAccess.Repositories;
using TrendFlow.DataAccess.Repositories.Contracts;
using TrendFlow.DataAccess.Repositories.Implementations;

namespace TrendFlow.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {

        string? connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<ApplicationDbContext>(
            options => options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

        services.AddScoped<IApplicationDbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IBrandRepository, BrandRepository>();

        return services;
    }
}
