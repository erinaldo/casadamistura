namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodBarras = c.String(),
                        Nome = c.String(),
                        Descricao = c.String(),
                        DataCadastro = c.DateTime(),
                        FornecedorId = c.Int(),
                        SubGrupoId = c.Int(),
                        Peso = c.Double(nullable: false),
                        PrecoCusto = c.Double(nullable: false),
                        PrecoVenda = c.Double(nullable: false),
                        Lucro = c.Double(nullable: false),
                        DescontoMaximo = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        QuantidadeEstocada = c.Double(nullable: false),
                        QuantidadeMinima = c.Double(nullable: false),
                        QuantidadeMaxima = c.Double(nullable: false),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.FornecedorId)
                .ForeignKey("dbo.SubGrupo", t => t.SubGrupoId)
                .Index(t => t.FornecedorId)
                .Index(t => t.SubGrupoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "SubGrupoId", "dbo.SubGrupo");
            DropForeignKey("dbo.Produtos", "FornecedorId", "dbo.Fornecedor");
            DropIndex("dbo.Produtos", new[] { "SubGrupoId" });
            DropIndex("dbo.Produtos", new[] { "FornecedorId" });
            DropTable("dbo.Produtos");
        }
    }
}
