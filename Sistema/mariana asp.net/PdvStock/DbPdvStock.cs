using PdvStock.Models;
using PdvStock.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PdvStock
{
    public class DbPdvStock : DbContext
    {

        public DbSet<AcaoService> AcaoService { get; set; }

        public DbSet<ModuloStatus> ModuloStatus { get; set; }

        public DbSet<ModuloService> ModuloService { get; set; }

        public DbSet<PerfilService> PerfilService { get; set; }

        public DbSet<DadosDoUsuario> DadosDoUsuario { get; set; }

        public DbSet<Grupo> Grupo { get; set; }

        public DbSet<SubGrupo> SubGrupo { get; set; }

        public DbSet<Fornecedor> Fornecedor { get; set; }

        public DbSet<Produtos> Produtos { get; set; }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Pdv> Pdv { get; set; }

        public DbSet<PdvItens> PdvItens { get; set; }

        public DbSet<FormaPgto> FormaPgto { get; set; }

        public DbSet<PdvPagamento> PdvPagamento { get; set; }

        public DbSet<PdvSangriaSuprimento> PdvSangriaSuprimento { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Comanda> Comanda { get; set; }

        public DbPdvStock()
            : base("name=DefaultConnection")
        {
            //Zera e recria a base ao iniciar
            //Database.SetInitializer(new DropCreateDatabaseAlways<DbPdvStock>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            //Remove pluralização dos nomes das entidades
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}