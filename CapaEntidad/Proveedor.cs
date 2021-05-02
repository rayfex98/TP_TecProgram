using System;

namespace CapaEntidad
{
    public class Proveedor
    {
        private Direccion _direccion;
        private string _razonSocial;
        private string _cuil;


        public Direccion Direccion
        {
            get { return this._direccion; }
            set { _direccion = value; }
        }
        public string RazonSocial
        {
            get { return this._razonSocial; }
            set { _razonSocial = value; }
        }
        public string Cuil
        {
            get { return this._cuil; }
            set { _cuil = value; }
        }

    }
}
