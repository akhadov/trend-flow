using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendFlow.Application.Services.Contracts;
using TrendFlow.Application.Services.Implementations;

namespace TrendFlow.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this  IServiceCollection services, IConfiguration configuration)
    {
        //services.AddScoped<IBrandService, BrandService>();
        return services;
    }
}
