using LojaJogos.Dominio.Entidades;
using LojaJogos.Infra.Dados.Contexto;
using LojaJogos.Infra.Dados.Repositorios;
using LojaJogos.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Testes.Testes_de_Infra_Dados
{
    [TestClass]
    public class CompraRepositorioTestes
    {
        private LojaJogosContexto _contexto;
        private CompraRepositorio _repositorio;
        private Compra _compra;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<LojaJogosContexto>());

            _contexto = new LojaJogosContexto();

            _repositorio = new CompraRepositorio();

            _compra = ConstrutorObjeto.CriarCompra();

            _contexto.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_compra()
        {
            _repositorio.Adicionar(_compra);

            var todoscompras = _repositorio.BuscarTudo();

            Assert.AreEqual(2, todoscompras.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_compra()
        {
            var compraEditado = _repositorio.BuscarPorId(1);
            compraEditado.FormaPagamento = "debito";

            _repositorio.Editar(compraEditado);

            var compraBuscado = _repositorio.BuscarPorId(1);

            Assert.AreEqual("debito", compraBuscado.FormaPagamento);
        }

        [TestMethod]
        public void Deveria_deletar_um_compra()
        {
            var compraDeletado = _repositorio.BuscarPorId(1);

            _repositorio.Deletar(compraDeletado);

            var todoscompras = _repositorio.BuscarTudo();

            Assert.AreEqual(0, todoscompras.Count);
        }

        [TestMethod]
        public void Deveria_buscar_compra_por_id()
        {
            var compraBuscado = _repositorio.BuscarPorId(1);

            Assert.IsNotNull(compraBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_compras()
        {
            var compraBuscado = _repositorio.BuscarTudo();

            Assert.IsNotNull(compraBuscado);
        }        
    }
}
