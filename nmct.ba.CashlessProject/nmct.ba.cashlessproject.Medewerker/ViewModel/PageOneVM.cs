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
            GetRegisters();
            Message = "Bezig met laden... Even geduld.";
            btnAanmelden = false;

        }

        private bool btnAanmelden = false;
        public bool BTNAanmelden
        {
            get { return btnAanmelden; }
            set { btnAanmelden = value; OnPropertyChanged("BTNAanmelden"); }
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
        private Register selectedkassa;
        public Register SelectedKassa
        {
            get { return selectedkassa; }
            set { selectedkassa = value; OnPropertyChanged("SelectedKassa"); }
        }
        private List<Register> kassalijst;
        public List<Register> KassaLijst
        {
            get { return kassalijst; }
            set { kassalijst = value; OnPropertyChanged("KassaLijst"); }
        }
        private List<Employee> listemployees;
        public List<Employee> ListEmployees
        {
            get { return listemployees; }
            set { listemployees = value; OnPropertyChanged("ListEmployees"); }
        }
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Loginco); }
        }
        // Login Method
        private async void Loginco()
        {
            if(SelectedKassa != null)
            {
                ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
                appvm.ToonRegister(SelectedKassa);
                ApplicationVM.token = GetToken();

                if (!ApplicationVM.token.IsError)
                {
                    List<Employee> emplist = new List<Employee>();
                    emplist = await GetEmployees();
                    ListEmployees = emplist;
                    foreach(Employee emp in ListEmployees)
                    {
                        string log = emp.Login;
                        if(log.Equals(Login))
                        {
                            appvm.GekozenEmployee = emp;
                            appvm.From = DateTime.Now;
                        }
                    }
                    InstellingenVM.Login = Login;
                    appvm.MenuVisibility = true;
                    //Naar product pagina gaan
                    appvm.ChangePage(new BestellingVM());
                }
                else
                {
                    Message = "Gelieve de correcte login gegevens in te vullen.";
                }
            }
            else
            {
                Message = "Gelieve een kassa te kiezen.";
            }
        }
        private async void GetRegisters()
        {
            List<Register> reglijst = new List<Register>();
            reglijst = await GetList();
            KassaLijst = reglijst;
            BTNAanmelden = true;
            Message = "";
        }
        //Verkrijgen van token
        private TokenResponse GetToken()
        {
            OAuth2Client client = new OAuth2Client(new Uri("http://localhost:7695/tokenME"));
            return client.RequestResourceOwnerPasswordAsync(Login, Password).Result;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/employee");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Employee> result = JsonConvert.DeserializeObject<List<Employee>>(json);
                    ListEmployees = result.OrderBy(o => o.EmployeeName).ToList();
                    return result;
                }
            }
            return null;
        }
        public async Task<List<Register>> GetList()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/registerME");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Register> result = JsonConvert.DeserializeObject<List<Register>>(json);
                    result = result.OrderBy(o => o.RegisterName).ToList(); ;
                    return result;
                }
            }
            return null;
        }

    }
}
