using System;
using LojaJogos.Dominio.Entidades;
using LojaJogos.Dominio.Exceções;
using LojaJogos.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaJogos.Testes.Testes_de_Dominio
{
    [TestClass]
    public class ClienteTestes
    {
        private Cliente _cliente;
        [TestInitialize]
        public void Inicializador()
        {
            _cliente = ConstrutorObjeto.CriarCliente();
        }
        [TestMethod]
        public void Cliente_deve_ter_primeiro_nome()
        {
            Assert.AreEqual("Nayara", _cliente.Nome);
        }

        [TestMethod]
        public void Cliente_deve_ter_sobrenome()
        {
            Assert.AreEqual("Athayde", _cliente.Sobrenome);
        }      
        [TestMethod]
        public void Cliente_deve_ser_valido()
        {
            _cliente.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_sem_nome_nao_deve_ser_valido()
        {
            _cliente.Nome = "";

            _cliente.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_sem_sobrenome_nao_deve_ser_valido()
        {
            _cliente.Sobrenome = "";

            _cliente.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_sem_telefone_nao_deve_ser_valido()
        {
            _cliente.Telefone = "";

            _cliente.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Cliente_sem_endereco_nao_deve_ser_valido()
        {
            _cliente.Endereco = null;

            _cliente.Validar();
        }
        [TestMethod]
        public void Cliente_nomecompleto_deve_trazer_nome_mais_sobrenome()
        {
            _cliente.Nome = "João";
            _cliente.Sobrenome = "Paulo";

            Assert.AreEqual("João Paulo", _cliente.NomeCompleto);
        }
    }
}
