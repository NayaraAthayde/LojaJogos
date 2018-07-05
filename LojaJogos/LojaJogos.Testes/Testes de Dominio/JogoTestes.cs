using System;
using LojaJogos.Dominio.Entidades;
using LojaJogos.Dominio.Exceções;
using LojaJogos.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaJogos.Testes.Testes_de_Dominio
{
    [TestClass]
    public class JogoTestes
    {
        private Jogo _jogo;
        [TestInitialize]
        public void Inicializador()
        {
            _jogo = ConstrutorObjeto.CriarJogo();
        }
        [TestMethod]
        public void Jogo_deve_ser_valido()
        {
            _jogo.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Jogo_com_preco_negativo_nao_deve_ser_valido()
        {
            _jogo.Preco = -1;
            _jogo.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Jogo_sem_nome_nao_deve_ser_valido()
        {
            _jogo.Nome = "";
            _jogo.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Jogo_com_data_lancamento_invalida_nao_deve_ser_valido()
        {
            _jogo.DataLancamento = new DateTime(0001, 01, 01);
            _jogo.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Jogo_sem_plataforma_nao_deve_ser_valido()
        {
            _jogo.Plataforma = "";
            _jogo.Validar();
        }
    }
}
