namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Grupo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Informacoes = c.String(),
                        DataCadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grupo");
        }
    }
}
