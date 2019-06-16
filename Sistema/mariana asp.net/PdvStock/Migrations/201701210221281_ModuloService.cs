namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModuloService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModuloService",
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
            DropForeignKey("dbo.ModuloService", "Status_Id", "dbo.ModuloStatus");
            DropIndex("dbo.ModuloService", new[] { "Status_Id" });
            DropTable("dbo.ModuloService");
        }
    }
}
