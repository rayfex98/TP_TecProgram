﻿using DAL;
using Entidades;
using System.Data;
using Excepciones;
using System.Collections.Generic;
namespace BLL
{
    public class NProducto
    {
        DProducto unProducto = new DProducto();
        DataTable dt = new DataTable();
        List<Producto> productos = new List<Producto>();
        Producto newproducto = new Producto();

        /// <summary>
        /// Carga nuevo producto
        /// </summary>
        /// <param name="_producto">nombre, precio de compra y venta, id de la categoria</param>
        /// <returns>true si realizo carga, lanza excepcion en otro caso</returns>
        public bool NuevoProducto(Producto _producto)
        {
            if (string.IsNullOrEmpty(_producto.Nombre) || _producto.PrecioCompra < 0 || _producto.PrecioVenta < 0 || _producto.Categoria.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            _producto.Nombre.ToLower();
            return unProducto.NuevoProducto(_producto);
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
                return true;
            }
            throw new FallaEnEliminacion();
        }
        /// <summary>
        /// Llena DT con productos habilitados
        /// columnas: 'Nombre','Categoria','Stock','Precio de compra','Precio de venta'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public List<Producto> RecuperarProductos()
        {

            DataTable products = unProducto.productosLista();
            foreach (DataRow item in products.Rows)
            {
                newproducto.Nombre = item.ItemArray[0].ToString();
                this.productos.Add(newproducto);
            }
            return productos;
        }
        /// <summary>
        /// Llena DT con productos de X categoria
        /// columnas: 'Nombre','Categoria','Stock','Precio de compra','Precio de venta'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable RecuperarProductoCategoria(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ExcepcionDeDatos();
            }
            dt = unProducto.ListaPorCategoria(nombre);
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
        /// <summary>
        /// Llena DT con productos habilitados
        /// columnas: 'nombre','categoria','Stock','Precio de compra','Precio de venta'
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public DataTable RecuperarProductoNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ExcepcionDeDatos();
            }
            dt = unProducto.ListaPorNombre(nombre);
            if (dt.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            return dt;
        }
    }
}
