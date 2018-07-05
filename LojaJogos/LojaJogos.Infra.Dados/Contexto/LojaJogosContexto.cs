using LojaJogos.Dominio.Entidades;
using LojaJogos.Infra.Dados.Configuracoes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Infra.Dados.Contexto
{
    public class LojaJogosContexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public LojaJogosContexto() : base("LojaJogosDB")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguracao());
            modelBuilder.Configurations.Add(new JogoConfiguracao());
            modelBuilder.Configurations.Add(new CompraConfiguracao());
        }
    }
}
