using System;
using System.Data.Entity;
using LojaJogos.Dominio.Entidades;
using LojaJogos.Infra.Dados.Contexto;
using LojaJogos.Infra.Dados.Repositorios;
using LojaJogos.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaJogos.Testes.Testes_de_Infra_Dados
{
    [TestClass]
    public class JogoRepositorioTestes
    {
        private LojaJogosContexto _contexto;
        private JogoRepositorio _repositorio;
        private Jogo _jogo;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<LojaJogosContexto>());

            _contexto = new LojaJogosContexto();

            _repositorio = new JogoRepositorio();

            _jogo = ConstrutorObjeto.CriarJogo();

            _contexto.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_jogo()
        {
            _repositorio.Adicionar(_jogo);

            var todosjogos = _repositorio.BuscarTudo();

            Assert.AreEqual(3, todosjogos.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_jogo()
        {
            var jogoEditado = _repositorio.BuscarPorId(1);
            jogoEditado.Nome = "novo jogo";

            _repositorio.Editar(jogoEditado);

            var jogoBuscado = _repositorio.BuscarPorId(1);

            Assert.AreEqual("novo jogo", jogoBuscado.Nome);
        }

        [TestMethod]
        public void Deveria_deletar_um_jogo()
        {
            var jogoDeletado = _repositorio.BuscarPorId(1);

            _repositorio.Deletar(jogoDeletado);

            var todosjogos = _repositorio.BuscarTudo();

            Assert.AreEqual(1, todosjogos.Count);
        }

        [TestMethod]
        public void Deveria_buscar_jogo_por_id()
        {
            var jogoBuscado = _repositorio.BuscarPorId(1);

            Assert.IsNotNull(jogoBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_jogos()
        {
            var jogoBuscado = _repositorio.BuscarTudo();

            Assert.IsNotNull(jogoBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_jogo_por_nome()
        {
            var jogoBuscado = _repositorio.BuscarPorNome("Jogo 1");

            Assert.IsNotNull(jogoBuscado);
        }
    }
}
