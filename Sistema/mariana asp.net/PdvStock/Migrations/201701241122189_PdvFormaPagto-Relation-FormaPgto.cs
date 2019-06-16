namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PdvFormaPagtoRelationFormaPgto : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PdvPagamento", name: "FormaPgto_Id", newName: "FormaPgtoId");
            RenameIndex(table: "dbo.PdvPagamento", name: "IX_FormaPgto_Id", newName: "IX_FormaPgtoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PdvPagamento", name: "IX_FormaPgtoId", newName: "IX_FormaPgto_Id");
            RenameColumn(table: "dbo.PdvPagamento", name: "FormaPgtoId", newName: "FormaPgto_Id");
        }
    }
}
