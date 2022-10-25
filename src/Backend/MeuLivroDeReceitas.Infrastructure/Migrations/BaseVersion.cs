using FluentMigrator.Builders.Create.Table;

namespace MeuLivroDeReceitas.Infrastructure.Migrations;

public static class BaseVersion
{
    public static ICreateTableColumnOptionOrWithColumnSyntax InsertColumnBase(ICreateTableWithColumnOrSchemaOrDescriptionSyntax tableName)
    {
        return tableName
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DataCriacao").AsDateTime().NotNullable();
    }
}
