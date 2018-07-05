using LojaJogos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Testes.Base
{
    public static class ConstrutorObjeto
    {
        public static Cliente CriarCliente()
        {
            return new Cliente
            {
                Id = 1,
                Nome = "Nayara",
                Sobrenome = "Athayde",
                Telefone = "49 9 9145-6227",
                Endereco = new Endereco
                {
                    Cep = "88519525",
                    Logradouro = "Rua Bezerra de Menezes",
                    Bairro = "Conta Dinheiro",
                    Cidade = "Lages",
                    Estado = "SC",
                    Numero = "123",
                    Complemento = ""
                }
            };
        }
        public static Endereco CriarEndereco()
        {
            return new Endereco
            {
                Cep = "88519525",
                Logradouro = "Rua Bezerra de Menezes",
                Bairro = "Conta Dinheiro",
                Cidade = "Lages",
                Estado = "SC",
                Numero = "123",
                Complemento = ""
            };
        }
        public static Jogo CriarJogo()
        {
            return new Jogo
            {
                Id = 1,
                DataLancamento = DateTime.Now,
                Nome = "Jogo 1",
                Plataforma = "PC",
                Preco = 120
            };
        }
        public static Compra CriarCompra()
        {
            var compra = new Compra();
            List<Jogo> listaJogos = new List<Jogo>();
            Jogo jogo1 = CriarJogo();
            Jogo jogo2 = CriarJogo();
            listaJogos.Add(jogo1);
            listaJogos.Add(jogo2);

            compra.Id = 1;
            compra.Cliente = CriarCliente();
            compra.FormaPagamento = "Dinheiro";
            compra.Jogos = listaJogos;
            return compra;

        }
    }

}
