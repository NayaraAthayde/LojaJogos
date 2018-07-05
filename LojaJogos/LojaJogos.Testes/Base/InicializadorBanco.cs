using LojaJogos.Dominio.Entidades;
using LojaJogos.Infra.Dados.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaJogos.Testes.Base
{
    public class InicializadorBanco<T> : DropCreateDatabaseAlways<LojaJogosContexto>
    {
        protected override void Seed(LojaJogosContexto context)
        {
            Compra compra = ConstrutorObjeto.CriarCompra();
        
            context.Compras.Add(compra);
            
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
