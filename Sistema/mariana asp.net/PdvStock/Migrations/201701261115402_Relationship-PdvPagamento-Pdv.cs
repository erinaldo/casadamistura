namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipPdvPagamentoPdv : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PdvPagamento", "Pdv_Id", "dbo.Pdv");
            DropIndex("dbo.PdvPagamento", new[] { "Pdv_Id" });
            RenameColumn(table: "dbo.PdvPagamento", name: "Pdv_Id", newName: "PdvId");
            AlterColumn("dbo.PdvPagamento", "PdvId", c => c.Int(nullable: false));
            CreateIndex("dbo.PdvPagamento", "PdvId");
            AddForeignKey("dbo.PdvPagamento", "PdvId", "dbo.Pdv", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PdvPagamento", "PdvId", "dbo.Pdv");
            DropIndex("dbo.PdvPagamento", new[] { "PdvId" });
            AlterColumn("dbo.PdvPagamento", "PdvId", c => c.Int());
            RenameColumn(table: "dbo.PdvPagamento", name: "PdvId", newName: "Pdv_Id");
            CreateIndex("dbo.PdvPagamento", "Pdv_Id");
            AddForeignKey("dbo.PdvPagamento", "Pdv_Id", "dbo.Pdv", "Id");
        }
    }
}
