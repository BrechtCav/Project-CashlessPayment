using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thinktecture.IdentityModel.Client;

namespace nmct.ba.cashlessproject.Medewerker.ViewModel
{
    class InstellingenVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        PageOneVM logvm = App.Current.MainWindow.DataContext as PageOneVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "Instellingen"; }
        }
        public InstellingenVM()
        {
        }
        // OldPassword
        private string oldpassword;
        public string OldPassword
        {
            get { return oldpassword; }
            set { oldpassword = value; OnPropertyChanged("OldPasword"); }
        }
        // Newpassword
        private string newpassword;
        public string NewPassword
        {
            get { return newpassword; }
            set { newpassword = value; OnPropertyChanged("NewPassword"); }
        }
        // Newpassword
        private string foutmelding;
        public string Foutmelding
        {
            get { return foutmelding; }
            set { foutmelding = value; OnPropertyChanged("Foutmelding"); }
        }
        public static string Login { get; set; }
        public ICommand ChangePasswordCommand
        {
            get { return new RelayCommand(ChangePas); }
        }
        int Gelukt = 0;
        private async void ChangePas()
        {
            Password NewPas = new Password();
            NewPas.Login = Login;
            NewPas.NewPassword = NewPassword;
            NewPas.OldPassword = OldPassword;
            if (NewPassword != null || NewPassword != "" || OldPassword != null || OldPassword != "")
            {
                int id = await ChangePassword(NewPas);
                if (Gelukt == 1)
                {
                    ApplicationVM.token = GetToken();
                }
                else
                {
                }
            }
        }
        private TokenResponse GetToken()
        {
            OAuth2Client client = new OAuth2Client(new Uri("http://localhost:7695/tokenME"));
            return client.RequestResourceOwnerPasswordAsync(Login, NewPassword).Result;
        }
        public async Task<int> ChangePassword(Password Newpas)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/EmployeeME");
                string json = JsonConvert.SerializeObject(Newpas);
                HttpResponseMessage response = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    Gelukt = 1;
                    Foutmelding = "Wachtwoord is gewijzigd";
                    return 1;
                }
                else
                {
                    Foutmelding = "Gelieve het juiste huidige wachtwoord in te geven.";
                    return 0;
                }
            }
        }
    }
}
