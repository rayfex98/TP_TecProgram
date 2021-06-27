using Excepciones;
using Entidades;
using DAL;
using System.Data;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class NDeposito
    {
        Deposito _unDeposito = new Deposito();
        DDeposito unDeposito = new DDeposito();

        /// <summary>
        /// Llena lista con stocks
        /// </summary>
        /// <returns>DataTable o Excepcion "NoEncontrado"</returns>
        public List<Stock> ListarDeposito()
        {
            _unDeposito.Stocks.Clear();
            DataTable deposito = unDeposito.ListadeDeposito();
            if(deposito.Rows.Count == 0)
            {
                throw new NoEncontrado();
            }
            foreach (DataRow item in deposito.Rows)
            {
                Stock nuevo = new Stock();
                nuevo.ID = (int)(item["id stock"]);
                nuevo.Cantidad = (int)item["cantidad"];
                nuevo.Producto.ID = (int)(item["id producto"]);
                nuevo.Producto.Nombre = item["producto"].ToString();
                nuevo.Producto.Categoria.Nombre = item["categoria"].ToString();
                _unDeposito.Stocks.Add(nuevo);
            }
            return _unDeposito.Stocks;
        }
        /// <summary>
        /// Quita en bbdd los detalles pertenecientes a una orden
        /// </summary>
        /// <param name="idOrden"></param>
        /// <returns>True o Excepcion "FallaEnEdicion"</returns>
        public bool QuitarDeDeposito(int idOrden)
        {
            if (unDeposito.QuitarDeDeposito(idOrden))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        /// <summary>
        /// Carga en bbdd los detalles pertenecientes a una orden
        /// </summary>
        /// <param name="idOrden"></param>
        /// <returns>True o Excepcion "FallaEnEdicion"</returns>
        public bool AgregarADeposito(int idOrden)
        {
            if (unDeposito.AgregarADeposito(idOrden))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
    }
}
