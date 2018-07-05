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
    public class JogoRepositorio
    {
        public LojaJogosContexto _contexto;

        public JogoRepositorio()
        {
            _contexto = new LojaJogosContexto();
        }

        public void Adicionar(Jogo entidade)
        {
            _contexto.Jogos.Add(entidade);

            _contexto.SaveChanges();
        }

        public Jogo BuscarPorId(int id)
        {
            return _contexto.Jogos.Find(id);
        }

        public Jogo BuscarPorNome(string nome)
        {
            return _contexto.Jogos
                .Where(p => p.Nome == nome)
                .FirstOrDefault();
        }
        public List<Jogo> BuscarTudo()
        {
            return _contexto.Jogos.ToList();
        }

        public void Deletar(Jogo entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Jogos.Attach(entidade);
            }

            _contexto.Jogos.Remove(entidade);

            _contexto.SaveChanges();
        }

        public void Editar(Jogo entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry(entidade);

            if (dbEntityEntry.State == EntityState.Detached)
            {
                _contexto.Jogos.Attach(entidade);
            }
            _contexto.SaveChanges();
        }

    }
}
