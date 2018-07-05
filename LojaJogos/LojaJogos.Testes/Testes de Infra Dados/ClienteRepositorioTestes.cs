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
    public class ClienteRepositorioTeste
    {
        private LojaJogosContexto _contexto;
        private ClienteRepositorio _repositorio;
        private Cliente _cliente;

        [TestInitialize]
        public void Inicializador()
        {
            Database.SetInitializer(new InicializadorBanco<LojaJogosContexto>());

            _contexto = new LojaJogosContexto();

            _repositorio = new ClienteRepositorio();

            _cliente = ConstrutorObjeto.CriarCliente();

            _contexto.Database.Initialize(true);
        }

        [TestMethod]
        public void Deveria_adicionar_um_novo_cliente()
        {
            _repositorio.Adicionar(_cliente);
            
            var todosClientes = _contexto.Clientes.ToList();

            Assert.AreEqual(2, todosClientes.Count);
        }

        [TestMethod]
        public void Deveria_editar_um_cliente()
        {
            var clienteEditado = _contexto.Clientes.Find(1);
            clienteEditado.Nome = "att";
            
            _repositorio.Editar(clienteEditado);
            
            var clienteBuscado = _contexto.Clientes.Find(1);

            Assert.AreEqual("att", clienteBuscado.Nome);
        }

        [TestMethod]
        public void Deveria_deletar_um_cliente()
        {
            var clienteDeletado = _contexto.Clientes.Find(1);
            
            _repositorio.Deletar(clienteDeletado);
            
            var todosClientes = _contexto.Clientes.ToList();

            Assert.AreEqual(0, todosClientes.Count);
        }

        [TestMethod]
        public void Deveria_buscar_cliente_por_id()
        {       
            var clienteBuscado = _repositorio.BuscarPorId(1);

            Assert.IsNotNull(clienteBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_todos_os_clientes()
        {
            var clienteBuscado = _repositorio.BuscarTudo();
            
            Assert.IsNotNull(clienteBuscado);
        }

        [TestMethod]
        public void Deveria_buscar_cliente_por_nome()
        {
            var clienteBuscado = _repositorio.BuscarPorNome("Nayara");
            
            Assert.IsNotNull(clienteBuscado);
        }

    }
}
