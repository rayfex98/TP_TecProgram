﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Deposito
    {
        private List<Stock> stocks;

        public List<Stock> Stocks
        {
            get { return stocks; }
            set { stocks = value; }
        }

    }
}