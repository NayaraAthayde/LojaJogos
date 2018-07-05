using LojaJogos.Dominio.Entidades;
using LojaJogos.Dominio.Exceções;
using LojaJogos.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Testes.Testes_de_Dominio
{
    [TestClass]
    public class CompraTestes
    {
        private Compra _compra;

        [TestInitialize]
        public void Inicializador()
        {
            _compra = ConstrutorObjeto.CriarCompra();
        }
        [TestMethod]
        public void Compra_deve_ser_valida()
        {
            _compra.Validar();
        }
        [TestMethod]
        public void Compra_deve_calcular_valor_total()
        {
            Assert.AreEqual(240, _compra.ValorTotal);
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Compra_sem_forma_pagamento_nao_deve_ser_valida()
        {
            _compra.FormaPagamento = "";

            _compra.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Compra_sem_cliente_nao_deve_ser_valida()
        {
            _compra.Cliente = null;

            _compra.Validar();
        }
    }
}
