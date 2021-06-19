﻿using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{
    public class NDetalleOrden
    {
        DDetalleOrden unDetalleOrden = new DDetalleOrden();

        public bool Nuevo(DetalleOrden _unDetalleOrden, int _idOrden)
        {
            return unDetalleOrden.Nuevo(_unDetalleOrden, _idOrden);
        }
        public bool Editar(DetalleOrden _unDetalleOrden, int _idOrden)
        {
            return unDetalleOrden.Editar(_unDetalleOrden, _idOrden);
        }
        public bool Eliminar(DetalleOrden _unDetalleOrden, int idorden)
        {
            return unDetalleOrden.Eliminar(_unDetalleOrden, idorden);
        }
        public bool EliminarPorOrden(DetalleOrden _unDetalleOrden)
        {
            return unDetalleOrden.EliminarPorOrden(_unDetalleOrden);
        }
        public DataTable ListarDetalleOrden()
        {
            return unDetalleOrden.ListadeDetalleOrden();
        }
    }
}