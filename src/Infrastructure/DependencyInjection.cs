﻿using Application.Abstractions.Caching;
using Application.Abstractions.Data;
using Application.Abstractions.Email;
using Dapper;
using Domain.Products;
using Domain.Users;
using Infrastructure.Caching;
using Infrastructure.Clock;
using Infrastructure.Database;
using Infrastructure.Email;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using SharedKernel;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration) =>
        services
            .AddServices()
            .AddDatabase(configuration)
            .AddCaching(configuration)
            .AddHealthChecks(configuration);

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IEmailService, EmailService>();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        string? connectionString = configuration.GetConnectionString("Database");
        Ensure.NotNullOrEmpty(connectionString);

        services.AddSingleton<IDbConnectionFactory>(_ =>
            new DbConnectionFactory(new NpgsqlDataSourceBuilder(connectionString).Build()));

        services.AddDbContext<ApplicationDbContext>(
            options => options
                .UseNpgsql(connectionString, npgsqlOptions =>
                    npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Default))
            .UseSnakeCaseNamingConvention());

        services.AddSingleton<PublishDomainEventsInterceptor>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    private static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
    {
        string redisConnectionString = configuration.GetConnectionString("Cache")!;

        services.AddStackExchangeRedisCache(options => options.Configuration = redisConnectionString);

        services.AddSingleton<ICacheService, CacheService>();

        return services;
    }

    private static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Database")!)
            .AddRedis(configuration.GetConnectionString("Cache")!);

        return services;
    }
}
