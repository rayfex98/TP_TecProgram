﻿using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace Datos
{
    public class DProducto
    {
        public string Nuevo(Producto unProducto)
        {
            //conexion con bbdd
            return "Ok";
        }
        public string Editar(Producto unProducto)
        {
            //conexion con bbdd
            return "Ok";
        }
        public Producto Eliminar(int idProducto)
        {
            Producto eliminado = new Producto();
            //conexion con bbdd
            return eliminado;
        }
        public int ID_Producto()
        {
            return 0;
        }

        public DataTable ListadeProductos()
        {
            DataTable dt = new DataTable();
            //busco en tabla
            return dt;
        }
    }
}
