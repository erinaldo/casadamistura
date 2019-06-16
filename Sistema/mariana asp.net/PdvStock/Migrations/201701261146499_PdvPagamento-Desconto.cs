namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PdvPagamentoDesconto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PdvItens", "Desconto", c => c.Double(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PdvItens", "Desconto");
        }
    }
}
