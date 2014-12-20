using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.CashlessProject.Klant.ViewModel
{
    class AccountVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        public string Name
        {
            get { return "Account"; }
        }
        public static string _naam;
        public string Naam
        {
            get { return _naam; }
            set { _naam = value; }
        }



    }
}
