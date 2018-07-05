using LojaJogos.Dominio.Contratos;
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
    public class CompraRepositorio : ICompraRepositorio
    {
        public LojaJogosContexto _contexto;
        JogoRepositorio _jogoRepositorio;
        public CompraRepositorio()
        {
            _contexto = new LojaJogosContexto();
            _jogoRepositorio = new JogoRepositorio();
        }
        public void Adicionar(Compra entidade)
        {
            _contexto.Compras.Add(entidade);

            _contexto.SaveChanges();
        }

        public Compra BuscarPorCliente(int id)
        {
            return _contexto.Compras
                .Where(p => p.Cliente.Id == id)
                .FirstOrDefault();
        }

        public Compra BuscarPorId(int id)
        {
            return _contexto.Compras.Find(id);
        }

        public List<Compra> BuscarTudo()
        {
            return _contexto.Compras.ToList();
        }

        public void Deletar(Compra entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Compras.Attach(entidade);
            }

            _contexto.Compras.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Compra entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Compras.Attach(entidade);
            }
            _contexto.SaveChanges();
        }
    }
}
