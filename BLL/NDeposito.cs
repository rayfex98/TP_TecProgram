using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using DAL;
using System.Data;

namespace BLL
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
