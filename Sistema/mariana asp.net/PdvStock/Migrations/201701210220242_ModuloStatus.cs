namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModuloStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModuloStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Url = c.String(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModuloStatus", t => t.Status_Id)
                .Index(t => t.Status_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModuloStatus", "Status_Id", "dbo.ModuloStatus");
            DropIndex("dbo.ModuloStatus", new[] { "Status_Id" });
            DropTable("dbo.ModuloStatus");
        }
    }
}
