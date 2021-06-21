﻿using Entidades;
using Excepciones;
using DAL;

namespace BLL
{
    public class NOrden
    {
        DOrden unOrden = new DOrden();

        public bool Nuevo(Orden _unOrden)
        {
            if(_unOrden.UsuarioCreador.ID < 0)
            {
                throw new ExcepcionDeDatos();
            }
            if (unOrden.Nuevo(_unOrden))
            {
                return true;
            }
            throw new FallaEnInsercion();
        }
        public bool Editar(Orden _unOrden)
        {
            if (unOrden.Editar(_unOrden))
            {
                return true;
            }
            throw new FallaEnEdicion();
        }
        public bool Eliminar(int _idOrden)
        {
            if (unOrden.Eliminar(_idOrden))
            {
                return true;
            }
            throw new FallaEnEliminacion();
        }
    }
}
