using LojaJogos.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Dominio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public string Telefone { get; set; }

        public string NomeCompleto
        {
            get
            {
                return String.Format("{0} {1}",
                    Nome, Sobrenome);
            }
        }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Nome))
                throw new DominioException("Nome inválido");
            if (String.IsNullOrWhiteSpace(Sobrenome))
                throw new DominioException("Sobrenome inválido");
            if (String.IsNullOrWhiteSpace(Telefone))
                throw new DominioException("Telefone inválido");
            if (Endereco == null)
                throw new DominioException("Endereço inválido!");

            Endereco.Validar();
        }
    }
}
