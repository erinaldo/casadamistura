namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableusuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(),
                        Cnpj = c.String(),
                        Status = c.Int(nullable: false),
                        Cep = c.String(nullable: false),
                        Endereco = c.String(nullable: false),
                        Numero = c.String(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                        Telefone = c.String(),
                        Celular = c.String(nullable: false),
                        Email = c.String(),
                        DataCadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
