using System;
using System.Data;
using Entidades;

namespace Negocio
{
    class NStock
    {
        public static string Crear(int _cant, Producto _producto)
        {
            Stock _stock = new()
            {
                Cantidad = _cant,
                Producto = _producto
            };            
            return _stock.Crear(_stock);
        }

        public static string Eliminar(int _idProducto)
        {
            Stock Obj = new();
            Obj.Producto.IdProducto = _idProducto;
            return Obj.Eliminar(Obj);
        }
        public static string Editar(int _idProducto, int _cant, Producto _producto)
        {
            Stock Obj = new Stock()
            {
                IdProd = _idProducto,
                Cantidad = _cant,
                Producto = _producto
            };

            return Obj.Editar(Obj);
        }
    }
}
