using Ardalis.Specification;
using Elang.Domain.Entities;
using Elang.Infrastructure.Data.DataAccess;
using Elang.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Elang.Infrastructure;
public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ElangDbContext>
            (
                options => options.UseNpgsql(
                    configuration.GetConnectionString("Default"),
                    builder => builder.MigrationsAssembly(typeof(ElangDbContext).Assembly.FullName)
                )
            );
        services.AddScoped<IRepositoryBase<Card>, CardsRepository>();
        services.AddScoped<IRepositoryBase<Topic>, TopicsRepository>();
    }
}
