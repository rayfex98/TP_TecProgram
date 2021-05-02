using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    public class Deposito //en principio hay un solo deposito y por eso no se instanciaria 
    {
        private HashSet<Stock> _stock = new HashSet<Stock>();

        public bool AgregarStock(Stock _stock)
        {
            return this._stock.Add(_stock);
        }


    }
}
