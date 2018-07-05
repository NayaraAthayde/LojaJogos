using LojaJogos.Dominio.Entidades;
using LojaJogos.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Infra.Dados.Repositorios
{
    public class ClienteRepositorio
    {
        public LojaJogosContexto _contexto;

        CompraRepositorio _compraRepositorio;
        public ClienteRepositorio()
        {
            _contexto = new LojaJogosContexto();
            _compraRepositorio = new CompraRepositorio();
        }

        public void Adicionar(Cliente entidade)
        {
            _contexto.Clientes.Add(entidade);

            _contexto.SaveChanges();
        }

        public Cliente BuscarPorId(int id)
        {
            return _contexto.Clientes.Find(id);
        }

        public Cliente BuscarPorNome(string nome)
        {
            return _contexto.Clientes
                .Where(p => p.Nome == nome)
                .FirstOrDefault();
        }
        public List<Cliente> BuscarTudo()
        {
            return _contexto.Clientes.ToList();
        }
        public void Deletar(Cliente entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Clientes.Attach(entidade);
            }

            _contexto.Clientes.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Cliente entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Clientes.Attach(entidade);
            }

            _contexto.SaveChanges();
        }
    }
}

