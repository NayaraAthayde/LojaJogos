using LojaJogos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Infra.Dados.Configuracoes
{
    public class CompraConfiguracao : EntityTypeConfiguration<Compra>
    {
        public CompraConfiguracao()
        {
            ToTable("TBCompra");

            HasKey(c => c.Id);

            HasRequired(c => c.Cliente)
                      .WithMany()
                      .WillCascadeOnDelete(true);
            Ignore(c => c.ValorTotal);

            HasMany(c => c.Jogos)
                      .WithMany()
                      .Map(cs =>
                      {
                          cs.MapLeftKey("JogoId");
                          cs.MapRightKey("CompraId");
                          cs.ToTable("TBCompraJogo");
                      });


        }
    }
}
