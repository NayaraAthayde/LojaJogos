using System;
using LojaJogos.Dominio.Entidades;
using LojaJogos.Dominio.Exceções;
using LojaJogos.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LojaJogos.Testes.Testes_de_Dominio
{
    [TestClass]
    public class EnderecoTestes
    {
        private Endereco _endereco;
        [TestInitialize]
        public void Inicializador()
        {
            _endereco = ConstrutorObjeto.CriarEndereco();
        }        
        [TestMethod]
        public void Endereco_deve_ser_valido()
        {
            _endereco.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Endereco_sem_logradouro_nao_deve_ser_valido()
        {
            _endereco.Logradouro = "";

            _endereco.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Endereco_sem_bairro_nao_deve_ser_valido()
        {
            _endereco.Bairro = "";

            _endereco.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Endereco_sem_cidade_nao_deve_ser_valido()
        {
            _endereco.Cidade = "";

            _endereco.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Endereco_sem_estado_nao_deve_ser_valido()
        {
            _endereco.Estado = "";

            _endereco.Validar();
        }
        [TestMethod]
        [ExpectedException(typeof(DominioException))]
        public void Endereco_sem_numero_nao_deve_ser_valido()
        {
            _endereco.Numero = "";

            _endereco.Validar();
        }
    }
}
