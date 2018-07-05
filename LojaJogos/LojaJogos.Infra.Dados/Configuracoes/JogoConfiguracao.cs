using LojaJogos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Infra.Dados.Configuracoes
{
    public class JogoConfiguracao : EntityTypeConfiguration<Jogo>
    {
        public JogoConfiguracao()
        {
            ToTable("TBJogo");

            HasKey(j => j.Id);            

            Property(j => j.Nome).IsRequired();
            Property(j => j.Plataforma).IsRequired();
            Property(j => j.Preco).IsRequired();
        }
    }
}
