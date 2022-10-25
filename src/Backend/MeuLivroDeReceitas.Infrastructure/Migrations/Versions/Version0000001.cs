using FluentMigrator;


namespace MeuLivroDeReceitas.Infrastructure.Migrations.Versions;

[Migration((int)VersionEnum.CreateTableUser, "Criar tabela usuario")]
public class Version0000001 : Migration
{
    public override void Down()
    {

    }
    public override void Up()
    {

        var table = BaseVersion.InsertColumnBase(Create.Table("Usuario"));

        table
            .WithColumn("Nome").AsString(100).NotNullable()
            .WithColumn("Email").AsString(100).NotNullable()
            .WithColumn("Password").AsString(2000).NotNullable()
            .WithColumn("Telefone").AsString(16).NotNullable();
    }
}
