﻿using System.Data;
using ddl_modulo;
using Entidades;

namespace bll_modulo
{
    public class NOrden
    {
        DOrden unOrden = new DOrden();

        public bool Nuevo(Orden _unOrden)
        {
            return unOrden.Nuevo(_unOrden);
        }
        public bool Editar(Orden _unOrden)
        {
            return unOrden.Editar(_unOrden);
        }
        public bool Eliminar(int _idOrden)
        {
            return unOrden.Eliminar(_idOrden);
        }
        public DataTable ListarOrden()
        {
            return unOrden.ListadeOrden();
        }
    }
}
