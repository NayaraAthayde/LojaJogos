using LojaJogos.Dominio.Exceções;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Dominio.Entidades
{
    public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Plataforma { get; set; }
        public double Preco { get; set; }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Nome))
                throw new DominioException("Nome não pode estar em branco");
            if (String.IsNullOrEmpty(Plataforma))
                throw new DominioException("Plataforma não pode estar em branco");
            if (DataLancamento == new DateTime(0001, 01, 01))
                throw new DominioException("Data lancamento inválida");
            if (Preco < 0)
                throw new DominioException("preco não pode ser menor que 0");
        }
    }
}
