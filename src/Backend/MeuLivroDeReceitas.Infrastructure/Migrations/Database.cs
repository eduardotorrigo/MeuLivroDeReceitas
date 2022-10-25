using Dapper;
using MySqlConnector;

namespace MeuLivroDeReceitas.Infrastructure.Migrations;

public static class Database
{
    public static void CreateDatabase(string connectionString, string databaseName)
    {
        using var myConnection = new MySqlConnection(connectionString);
        var context = new DynamicParameters();
        context.Add("name", databaseName);
        var records = myConnection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", context);
        if (!records.Any())
        {
            myConnection.Execute($"CREATE DATABASE {databaseName}");
        }
    }
}
