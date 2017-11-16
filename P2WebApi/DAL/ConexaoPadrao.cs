using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace P2WebApi.DAL
{
    public class ConexaoPadrao : DbContext
    {
        public ConexaoPadrao()
            : base("name=ConexaoPadrao")
        {
            Database.SetInitializer<ConexaoPadrao>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

        public System.Data.Entity.DbSet<P2WebApi.Models.Funcionarios> Funcionarios { get; set; }

        public System.Data.Entity.DbSet<P2WebApi.Models.Vendas> Vendas { get; set; }

        public System.Data.Entity.DbSet<P2WebApi.Models.CustosDespesas> CustosDespesas { get; set; }

        public System.Data.Entity.DbSet<P2WebApi.Models.Produtos> Produtos { get; set; }
    }
}