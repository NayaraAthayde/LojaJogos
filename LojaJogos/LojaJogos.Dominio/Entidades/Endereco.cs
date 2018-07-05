using LojaJogos.Dominio.Exceções;
using System;

namespace LojaJogos.Dominio.Entidades
{
    public class Endereco
    {        
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public void Validar()
        {
            if (String.IsNullOrWhiteSpace(Numero))
                throw new DominioException("Numero inválido");
            if (String.IsNullOrWhiteSpace(Logradouro))
                throw new DominioException("Logradouro inválido");
            if (String.IsNullOrWhiteSpace(Bairro))
                throw new DominioException("Bairro inválido");
            if (String.IsNullOrWhiteSpace(Estado))
                throw new DominioException("Estado inválido");
            if (String.IsNullOrWhiteSpace(Cidade))
                throw new DominioException("Cidade inválido");
            if (String.IsNullOrWhiteSpace(Cep))
                throw new DominioException("Cep inválido");
        }
    }
}