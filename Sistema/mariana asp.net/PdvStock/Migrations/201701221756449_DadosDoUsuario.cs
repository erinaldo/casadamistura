namespace PdvStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DadosDoUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DadosDoUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                        Departamento = c.String(),
                        Email = c.String(),
                        Telefone = c.String(),
                        Usuario = c.String(),
                        Cpf = c.String(),
                        CentroCusto = c.String(),
                        UsuarioAtivo = c.Boolean(nullable: false),
                        Erro = c.Boolean(nullable: false),
                        ErroMsg = c.String(),
                        ErroCode = c.Int(nullable: false),
                        Gestores = c.Boolean(nullable: false),
                        GestorDesteSistema = c.Boolean(nullable: false),
                        AdministradorDesteSistema = c.Boolean(nullable: false),
                        LogaTudo = c.Boolean(nullable: false),
                        SistemaId = c.Int(nullable: false),
                        Informacoes = c.String(),
                        Navegador = c.String(),
                        IP = c.String(),
                        UrlRequisicao = c.String(),
                        SimularUsuario = c.String(),
                        Simulacao = c.Boolean(nullable: false),
                        SimuladoPor = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DadosDoUsuario");
        }
    }
}
