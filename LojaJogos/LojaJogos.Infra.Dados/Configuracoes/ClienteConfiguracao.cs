using LojaJogos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Infra.Dados.Configuracoes
{
    public class ClienteConfiguracao : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguracao()
        {
            ToTable("TBCliente");

            HasKey(c => c.Id);

            Ignore(c => c.NomeCompleto);

            Property(c => c.Nome).IsRequired();
            Property(c => c.Sobrenome).IsRequired();
            Property(c => c.Telefone).IsRequired();
        }
    }
}
