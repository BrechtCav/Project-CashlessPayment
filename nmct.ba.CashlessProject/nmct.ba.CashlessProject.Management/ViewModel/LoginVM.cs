using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thinktecture.IdentityModel.Client;

namespace nmct.ba.CashlessProject.Management.ViewModel
{
    class LoginVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        InstellingenVM ivm = App.Current.MainWindow.DataContext as InstellingenVM;
        public string Name
        {
            get { return "Login"; }
        }
        //Username
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }
        //Paswoord
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
        //Foutmelding
        private string _error;
        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged("Error"); }
        }

        //ICommand wanneer er op aanmelden word gedrukt
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }
        // Login Method
        private void Login()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            ApplicationVM.token = GetToken();
            InstellingenVM.Login = Username;
            if (!ApplicationVM.token.IsError)
            {
                //Tonen van menu
                appvm.MenuVisibility = true;
                //Naar product pagina gaan
                appvm.ChangePage(new PageOneVM());
                //Tonen van organisatieinfo
                appvm.GetDBInfo();
                appvm.klok();
            }
            else
            {
                Error = "Gebruikersnaam of paswoord kloppen niet";
            }
        }
        //Verkrijgen van token
        private TokenResponse GetToken()
        {
            OAuth2Client client = new OAuth2Client(new Uri("http://localhost:7695/token"));
            return client.RequestResourceOwnerPasswordAsync(Username, Password).Result;
        }
    }
}
