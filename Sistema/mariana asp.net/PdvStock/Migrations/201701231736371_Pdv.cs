namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pdv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pdv",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientesId = c.Int(),
                        Cpf = c.String(),
                        ValorTotal = c.Double(nullable: false),
                        NumeroVenda = c.String(),
                        DataVenda = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClientesId)
                .Index(t => t.ClientesId);
            
            CreateTable(
                "dbo.PdvItens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comissao = c.Double(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ValorUnitario = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        DataCadastro = c.String(),
                        DadosDoUsuario_Id = c.Int(),
                        Pdv_Id = c.Int(),
                        Produtos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DadosDoUsuario", t => t.DadosDoUsuario_Id)
                .ForeignKey("dbo.Pdv", t => t.Pdv_Id)
                .ForeignKey("dbo.Produtos", t => t.Produtos_Id)
                .Index(t => t.DadosDoUsuario_Id)
                .Index(t => t.Pdv_Id)
                .Index(t => t.Produtos_Id);
            
            CreateTable(
                "dbo.PdvPagamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCadastro = c.DateTime(nullable: false),
                        Valor = c.Double(nullable: false),
                        Parcelado = c.Int(nullable: false),
                        QtdeParcela = c.Int(nullable: false),
                        FormaPgto_Id = c.Int(),
                        Pdv_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FormaPgto", t => t.FormaPgto_Id)
                .ForeignKey("dbo.Pdv", t => t.Pdv_Id)
                .Index(t => t.FormaPgto_Id)
                .Index(t => t.Pdv_Id);
            
            CreateTable(
                "dbo.FormaPgto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        MaxParcela = c.Int(nullable: false),
                        JurosAcrescidos = c.Double(nullable: false),
                        DataCadastro = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PdvSangriaSuprimento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValorUnitario = c.Double(nullable: false),
                        TipoSangSup = c.Int(nullable: false),
                        DataCadastro = c.String(),
                        DadosDoUsuario_Id = c.Int(),
                        Pdv_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DadosDoUsuario", t => t.DadosDoUsuario_Id)
                .ForeignKey("dbo.Pdv", t => t.Pdv_Id)
                .Index(t => t.DadosDoUsuario_Id)
                .Index(t => t.Pdv_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PdvSangriaSuprimento", "Pdv_Id", "dbo.Pdv");
            DropForeignKey("dbo.PdvSangriaSuprimento", "DadosDoUsuario_Id", "dbo.DadosDoUsuario");
            DropForeignKey("dbo.PdvPagamento", "Pdv_Id", "dbo.Pdv");
            DropForeignKey("dbo.PdvPagamento", "FormaPgto_Id", "dbo.FormaPgto");
            DropForeignKey("dbo.PdvItens", "Produtos_Id", "dbo.Produtos");
            DropForeignKey("dbo.PdvItens", "Pdv_Id", "dbo.Pdv");
            DropForeignKey("dbo.PdvItens", "DadosDoUsuario_Id", "dbo.DadosDoUsuario");
            DropForeignKey("dbo.Pdv", "ClientesId", "dbo.Clientes");
            DropIndex("dbo.PdvSangriaSuprimento", new[] { "Pdv_Id" });
            DropIndex("dbo.PdvSangriaSuprimento", new[] { "DadosDoUsuario_Id" });
            DropIndex("dbo.PdvPagamento", new[] { "Pdv_Id" });
            DropIndex("dbo.PdvPagamento", new[] { "FormaPgto_Id" });
            DropIndex("dbo.PdvItens", new[] { "Produtos_Id" });
            DropIndex("dbo.PdvItens", new[] { "Pdv_Id" });
            DropIndex("dbo.PdvItens", new[] { "DadosDoUsuario_Id" });
            DropIndex("dbo.Pdv", new[] { "ClientesId" });
            DropTable("dbo.PdvSangriaSuprimento");
            DropTable("dbo.FormaPgto");
            DropTable("dbo.PdvPagamento");
            DropTable("dbo.PdvItens");
            DropTable("dbo.Pdv");
        }
    }
}
