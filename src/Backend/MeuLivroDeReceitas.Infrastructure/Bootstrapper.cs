using System.Reflection;
using FluentMigrator.Runner;
using MeuLivroDeReceitas.Domain.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuLivroDeReceitas.Infrastructure;
public static class Bootstrapper
{
    public static void AddRepositorio(this IServiceCollection services, IConfiguration configurationManger)
    {
        AddFluentMigrator(services, configurationManger);
    }
    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManger)
    {
        services.AddFluentMigratorCore().ConfigureRunner(x => x.AddMySql5()
        .WithGlobalConnectionString(configurationManger.GetFullConection())
        .ScanIn(Assembly.Load("MeuLivroDeReceitas.Infrastructure")
        ).For.All());
    }
}
