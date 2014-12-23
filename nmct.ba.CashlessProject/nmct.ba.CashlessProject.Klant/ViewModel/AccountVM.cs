using GalaSoft.MvvmLight.Command;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace nmct.ba.CashlessProject.Klant.ViewModel
{
    class AccountVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        public string Name
        {
            get { return "Account"; }
        }
        
        public AccountVM()
        {
        }
        private byte[] eidpic;
        public byte[] eIDPic
        {
            get{return eidpic;}
            set{eidpic = value; OnPropertyChanged("eIDPic");}
        }
        public static Customer Customer { get; set; }
    }
}