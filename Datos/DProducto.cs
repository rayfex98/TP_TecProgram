using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class DProducto
    {
        //crear obj producto hardcodeado y retornar

        public void Insertar(Producto item) {                      
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsetarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",item.nombre);
            comando.Parameters.AddWithValue("@categoria",item.categ);
            comando.Parameters.AddWithValue("@idproducto",item.idprod);
            comando.Parameters.AddWithValue("@preciocompra",item.preciocompra);
            comando.Parameters.AddWithValue("@precioventa",item.precioventa);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        
        }

        public void Editar(Productos item) {                      
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre",item.nombre);
            comando.Parameters.AddWithValue("@categoria",item.categ);
            comando.Parameters.AddWithValue("@idproducto",item.idprod);
            comando.Parameters.AddWithValue("@preciocompra",item.preciocompra);
            comando.Parameters.AddWithValue("@precioventa",item.precioventa);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        
        }

        public void Eliminar(int idProducto) {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idProducto",idprod);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

    }
}
