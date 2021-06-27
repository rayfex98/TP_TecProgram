using DAL;
using Entidades;
using System.Data;
using Excepciones;
using System.Collections.Generic;
using System;

namespace BLL
{
    public class NProducto
    {
        DProducto unProducto = new DProducto();
        List<Producto> productos = new List<Producto>();

        /// <summary>
        /// Carga nuevo producto
        /// </summary>
        /// <param name="_producto">nombre, precio de compra y venta, id de la categoria</param>
        /// <returns>true, ExcepcionDeDatos o FallaEnInsercion </returns>
        public bool NuevoProducto(Producto _producto)
        {
            if (string.IsNullOrEmpty(_producto.Nombre) || _producto.PrecioCompra < 0 || _producto.PrecioVenta < 0 || _producto.Categoria.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            _producto.Nombre.ToLower();
            if (unProducto.NuevoProducto(_producto))
            {
                _producto.ID = unProducto.UltimoProducto();
                productos.Add(_producto);
                return true;
            }
            else
            {
                throw new FallaEnInsercion();
            }
        }
        /// <summary>
        /// Editar en la bbdd, para los campos que no requiera editar se puede asignar un NULL en el objeto
        /// </summary>
        /// <param name="_producto">id + datos a editar</param>
        /// <returns>true si realizo carga, lanza excepcion en otro caso</returns>
        public bool EditarProducto(Producto _producto)
        {
            if (_producto.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            _producto.Nombre.ToLower();
            if (unProducto.EditarProducto(_producto))
            {
                CargarLista();
                return true;
            }
            throw new FallaEnEdicion();
        }
        /// <summary>
        /// Eliminacion de la bbdd,
        /// Requiero el id del producto 
        /// </summary>
        /// <param name="_idProducto">requiero el id a eliminar</param>
        /// <returns>true o Excepcion "FallaEnEliminacion"</returns>
        public bool EliminarProducto(int _idProducto)
        {
            if (_idProducto < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unProducto.EliminarProducto(_idProducto))
            {
                CargarLista();
                return true;
            }
            throw new FallaEnEliminacion();
        }
        public void CargarLista()
        {
            productos.Clear();
            DataTable products = unProducto.ListadeProductos();
            foreach (DataRow item in products.Rows)
            {
                Producto newproducto = new Producto();
                Categoria nuevacat = new Categoria();
                newproducto.ID = (int)item["id_producto"];
                newproducto.Nombre = item["nombre"].ToString();
                nuevacat.ID = (int)Convert.ToSingle(item["idcategoria"]);
                nuevacat.Nombre = item["categoria"].ToString();
                newproducto.Categoria = nuevacat;
                newproducto.PrecioCompra = (int)Convert.ToSingle(item["Precio de compra"]);
                newproducto.PrecioVenta = (int)Convert.ToSingle(item["Precio de venta"]);
                productos.Add(newproducto);
            }
        }
        /// <summary>
        /// Llena lista con productos para consumir en DGV o CMBBOX
        /// IMPORTANTE LLAMAR A CargarLista() primero
        /// columnas: 'id','nombre','Categoria','Stock','Precio de compra','Precio de venta'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public List<Producto> RecuperarProductos()
        {
            if(productos.Count == 0)
            {
                throw new NoEncontrado();
            }
            return productos;
        }
        /// <summary>
        /// Llena DT con productos de X categoria
        /// columnas: 'Nombre','Categoria','Stock','Precio de compra','Precio de venta'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public List<Producto> RecuperarProductoCategoria(string nombre)
        {
            List<Producto> filtro = new List<Producto>();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ExcepcionDeDatos();
            }
            foreach (Producto prod in productos)
            {
                if(prod.Categoria.Nombre == nombre)
                {
                    filtro.Add(prod);
                }
            }
            return filtro;
        }
        /// <summary>
        /// Llena DT con productos habilitados
        /// columnas: 'nombre','categoria','Stock','Precio de compra','Precio de venta'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public List<Producto> RecuperarProductoNombre(string nombre)
        {
            List<Producto> filtro = new List<Producto>();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ExcepcionDeDatos();
            }
            foreach (Producto prod in productos)
            {
                if (prod.Nombre == nombre)
                {
                    filtro.Add(prod);
                }
            }
            return filtro;
        }
    }
}
