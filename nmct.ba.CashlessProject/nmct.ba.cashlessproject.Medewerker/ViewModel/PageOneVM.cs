using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Thinktecture.IdentityModel.Client;

namespace nmct.ba.cashlessproject.Medewerker.ViewModel
{
    class PageOneVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "First page"; }
        }
        public PageOneVM()
        {
            klok();
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("Message"); }
        }       
        private string _tijd;
        public string Tijd
        {
            get { return _tijd; }
            set { _tijd = value; OnPropertyChanged("Tijd"); }
        }
        private string _login;
        public string Login
        {
            get { return _login; }
            set { _login = value; OnPropertyChanged("Login"); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public void klok()
        {
            dispatcherTimer.Tick += new EventHandler(this.kloktik);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void kloktik(object sender, EventArgs e)
        {
            string dag = DateTimeFormatInfo.CurrentInfo.GetDayName(DateTime.Now.DayOfWeek);
            Tijd = char.ToUpper(dag[0]) + dag.Substring(1) + " " + DateTime.Now.ToString();
        }
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Loginco); }
        }
        // Login Method
        private void Loginco()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            ApplicationVM.token = GetToken();

            if (!ApplicationVM.token.IsError)
            {
                appvm.MenuVisibility = true;
                //Naar product pagina gaan
                appvm.ChangePage(new BestellingVM());
            }
            else
            {
                Message = "Niet gelukt";
            }
        }
        //Verkrijgen van token
        private TokenResponse GetToken()
        {
            OAuth2Client client = new OAuth2Client(new Uri("http://localhost:7695/tokenME"));
            return client.RequestResourceOwnerPasswordAsync(Login, Password).Result;
        }
    }
}
