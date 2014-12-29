using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.cashlessproject.Medewerker.ViewModel
{
    class BestellingVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "First page"; }
        }
    }
}
