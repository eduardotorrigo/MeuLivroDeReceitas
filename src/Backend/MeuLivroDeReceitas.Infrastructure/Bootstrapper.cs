using System.Reflection;
using FluentMigrator.Runner;
using Pomelo.EntityFrameworkCore;
using MeuLivroDeReceitas.Domain.Extension;
using MeuLivroDeReceitas.Domain.Repository;
using MeuLivroDeReceitas.Infrastructure.RepositoryAccess;
using MeuLivroDeReceitas.Infrastructure.RepositoryAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuLivroDeReceitas.Infrastructure;
public static class Bootstrapper
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configurationManger)
    {
        AddFluentMigrator(services, configurationManger);
        
        AddContext(services, configurationManger);
        AddUnitWork(services);
        AddRepositoryUser(services);
    }
    private static void AddContext(IServiceCollection service, IConfiguration configurationManger)
    {
        var versionService = new MySqlServerVersion(new Version(8, 0, 26));
        var connectionString = configurationManger.GetFullConection();
        service.AddDbContext<MeuLivroDeReceitasContext>(dbContextOptions => dbContextOptions.UseMySql(connectionString, versionService));
    }
    public static void AddUnitWork(IServiceCollection service)
    {
        service.AddScoped<IUnitWork, UnitWork>();
    }
    public static void AddRepositoryUser(IServiceCollection services)
    {
        services.AddScoped<IUserWriteOnlyRepository, RepositoryUser>()
        .AddScoped<IUserReadOnlyRepository, RepositoryUser>();
    }
    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManger)
    {
        services.AddFluentMigratorCore().ConfigureRunner(x => x.AddMySql5()
        .WithGlobalConnectionString(configurationManger.GetFullConection())
        .ScanIn(Assembly.Load("MeuLivroDeReceitas.Infrastructure")
        ).For.All());
    }
}
