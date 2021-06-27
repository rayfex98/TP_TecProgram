using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using System.Data;

namespace DAL
{
    public class DDeposito
    {
        DStock unstock = new DStock();
        DataTable dt = new DataTable();
        readonly Conexion db = new Conexion();
        public DataTable ListadeDeposito()// muestra 
        {
            string query = string.Format("vista_stock");
            dt = db.LeerPorComando(query);
            return dt;
        }
        public bool QuitarDeDeposito(int idOrden)
        {
            int idproducto;
            int cantidad;

            string query = string.Format("exec quitardestock @orden= {0};", idOrden);
            dt = db.LeerPorComando(query);
            foreach (DataRow item in dt.Rows)
            {
                cantidad = int.Parse(item.ItemArray[0].ToString());
                idproducto = int.Parse(item.ItemArray[1].ToString());
                if (false == unstock.RestarStock(idproducto, cantidad))
                {
                    return false;
                }
            }
            return true;
        }
        public bool AgregarADeposito(int idOrden)
        {
            int idproducto;
            int cantidad;

            string query = string.Format("exec quitardestock @orden= {0};", idOrden);
            dt = db.LeerPorComando(query);
            foreach (DataRow item in dt.Rows)
            {
                cantidad = int.Parse(item.ItemArray[0].ToString());
                idproducto = int.Parse(item.ItemArray[1].ToString());
                if (false == unstock.AgregarStock(idproducto, cantidad))
                {
                    return false;
                }
            }
            return true;
        }


    }
}