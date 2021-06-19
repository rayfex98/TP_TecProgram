﻿using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class NOrdenCompra
    {
        DOrdenCompra unOrdenCompra = new DOrdenCompra();

        public bool NuevoOrden(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.NuevoOrden(_unOrdenCompra);
        }
        public bool EditarOrden(OrdenDeCompra _unOrdenCompra)
        {
            return unOrdenCompra.EditarOrden(_unOrdenCompra);
        }
        public bool EliminarOrden(int _idOrden)
        {
            return unOrdenCompra.EliminarOrden(_idOrden);
        }
        public DataTable ListarOrdenCompra()
        {
            return unOrdenCompra.ListadeOrdenCompra();
        }
        public DataTable OrdenPendiente()
        {
            return unOrdenCompra.OrdenPendiente();
        }
    }
}