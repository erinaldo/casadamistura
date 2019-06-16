namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubGrupo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubGrupo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Informacoes = c.String(),
                        DataCadastro = c.DateTime(),
                        GrupoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grupo", t => t.GrupoId, cascadeDelete: true)
                .Index(t => t.GrupoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubGrupo", "GrupoId", "dbo.Grupo");
            DropIndex("dbo.SubGrupo", new[] { "GrupoId" });
            DropTable("dbo.SubGrupo");
        }
    }
}
