﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.CashlessProject.Klant.ViewModel
{
    class SaldoVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Saldo"; }
        }
        public SaldoVM()
        {

        }
    }
}
