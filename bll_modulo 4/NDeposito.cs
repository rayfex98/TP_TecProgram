using System;
using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NDeposito
    {
        DDeposito unDeposito = new DDeposito();

        public DataTable ListarDeposito(int idproducto)
        {
            return unDeposito.ListadeDeposito(idproducto);
        }
    }
}
