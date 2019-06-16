namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PdvItensRelationProdutos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PdvItens", "Pdv_Id", "dbo.Pdv");
            DropIndex("dbo.PdvItens", new[] { "Pdv_Id" });
            RenameColumn(table: "dbo.PdvItens", name: "Pdv_Id", newName: "PdvId");
            RenameColumn(table: "dbo.PdvItens", name: "Produtos_Id", newName: "ProdutosId");
            RenameIndex(table: "dbo.PdvItens", name: "IX_Produtos_Id", newName: "IX_ProdutosId");
            AlterColumn("dbo.PdvItens", "PdvId", c => c.Int(nullable: false));
            CreateIndex("dbo.PdvItens", "PdvId");
            AddForeignKey("dbo.PdvItens", "PdvId", "dbo.Pdv", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PdvItens", "PdvId", "dbo.Pdv");
            DropIndex("dbo.PdvItens", new[] { "PdvId" });
            AlterColumn("dbo.PdvItens", "PdvId", c => c.Int());
            RenameIndex(table: "dbo.PdvItens", name: "IX_ProdutosId", newName: "IX_Produtos_Id");
            RenameColumn(table: "dbo.PdvItens", name: "ProdutosId", newName: "Produtos_Id");
            RenameColumn(table: "dbo.PdvItens", name: "PdvId", newName: "Pdv_Id");
            CreateIndex("dbo.PdvItens", "Pdv_Id");
            AddForeignKey("dbo.PdvItens", "Pdv_Id", "dbo.Pdv", "Id");
        }
    }
}
