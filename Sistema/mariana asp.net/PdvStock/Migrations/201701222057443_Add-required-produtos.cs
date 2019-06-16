namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addrequiredprodutos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Nome", c => c.String());
        }
    }
}
