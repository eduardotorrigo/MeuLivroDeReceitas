using Microsoft.Extensions.Configuration;


namespace MeuLivroDeReceitas.Domain.Extension;

public static class RepositorioExtension
{
    public static string GetNameDataBase(this IConfiguration configurationManager)
    {
        var dataName = configurationManager.GetConnectionString("DatabaseName");
        return dataName;
    }
    public static string GetConnection(this IConfiguration configurationManager)
    {
        var connectionString = configurationManager.GetConnectionString("DefaultContext");
        return connectionString;
    }
    public static string GetFullConection(this IConfiguration configurationManager)
    {
        var dataName = configurationManager.GetNameDataBase();
        var connection = configurationManager.GetConnection();
        return $"{connection}Database={dataName}";
    }
}