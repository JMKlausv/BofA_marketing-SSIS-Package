
using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Hangfire;
using Infrastructure.Services.BackgroundJobs;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("appDbConnectionString"),
                 builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));


        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<AppDbContextInitializer>();
        services.AddScoped<ISSISManager, SSISManager>();
        services.AddScoped<IBackgroundJobs, BackgroundJobs>();

        services.AddHangfire(x =>
        {
            x.UseSqlServerStorage(configuration.GetConnectionString("hangfireDbConnectionString"));
        });
        services.AddHangfireServer();


        return services;
    }
}

