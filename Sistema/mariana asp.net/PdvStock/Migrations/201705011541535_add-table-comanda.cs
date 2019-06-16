namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablecomanda : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comanda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoBarrasComanda = c.String(),
                        UsuarioId = c.Int(nullable: false),
                        ProdutosId = c.Int(nullable: false),
                        Quantidade = c.Double(nullable: false),
                        DataCadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtos", t => t.ProdutosId, cascadeDelete: false)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.ProdutosId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comanda", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Comanda", "ProdutosId", "dbo.Produtos");
            DropIndex("dbo.Comanda", new[] { "UsuarioId" });
            DropIndex("dbo.Comanda", new[] { "ProdutosId" });
            DropTable("dbo.Comanda");
        }
    }
}
