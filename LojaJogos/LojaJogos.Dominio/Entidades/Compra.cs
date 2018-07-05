using LojaJogos.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Dominio.Entidades
{
    public class Compra
    {
        public int Id { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual List<Jogo> Jogos { get; set; }
        public double ValorTotal
        {
            get
            {
                double valor = new double();
                foreach (var jogo in Jogos)
                {
                    valor += jogo.Preco;
                }
                return valor;
            }
        }
        public string FormaPagamento { get; set; }

        public void Validar()
        {
            if (Cliente == null)
                throw new DominioException("Compra precisa de um cliente");
            if (Jogos.Count == 0)
                throw new DominioException("Compra precisa de pelo menos um jogo");
            if (String.IsNullOrEmpty(FormaPagamento))
                throw new DominioException("Compra deve ter uma forma de pagamento");
        }
    }
}
