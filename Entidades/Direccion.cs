using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Direccion
    {
        private string _altura;
        private string _calle;
        private string _codigoPostal;
        private string _localidad;
        private string _provincia;

        public Direccion()
        {

        }
        public string Altura
        {
            get { return this._altura; }
            set { _altura = value; }
        }
        public string Calle
        {
            get { return this._calle; }
            set { _calle = value; }
        }
        public string CodigoPostal
        {
            get { return this._codigoPostal; }
            set { _codigoPostal = value; }
        }
        public string Localidad
        {
            get { return this._localidad; }
            set { _localidad = value; }
        }
        public string Provincia
        {
            get { return this._provincia; }
            set { _provincia = value; }
        }
    }
}
