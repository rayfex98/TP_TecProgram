using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Entidades
{
    public abstract class Reporte
    {
        private DataTable _tablaReporte;

        public DataTable TablaReporte
        {
            get { return _tablaReporte; }
            set { _tablaReporte = value; }
        }

    }
}