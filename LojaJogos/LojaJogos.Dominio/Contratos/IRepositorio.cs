using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Dominio.Contratos
{
    public interface IRepositorio<T>
    {
        void Adicionar(T entidade);

        void Editar(T entidade);

        T BuscarPorId(int id);

        List<T> BuscarTudo();

        void Deletar(T entidade);
    }
}
