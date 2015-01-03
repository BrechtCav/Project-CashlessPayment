using GalaSoft.MvvmLight.CommandWpf;
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
    class ApplicationVM : ObservableObject
    {
        private const string URL = "http://localhost:7695/api";
        public static TokenResponse token = null;
        public ApplicationVM()
        {
            
            Pages.Add(new BestellingVM());
            Pages.Add(new InstellingenVM());
            Startpage.Add(new PageOneVM());
            // Add other pages

            CurrentPage = Startpage[0];
        }

        
        private bool menuvisibility = false;
        public bool MenuVisibility
        {
            get { return menuvisibility; }
            set { menuvisibility = value; OnPropertyChanged("MenuVisibility"); }
        }
        private object currentPage;
        public object CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
        }
        private Register gekozenkassa;
        public Register GekozenKassa
        {
            get { return gekozenkassa; }
            set { gekozenkassa = value; OnPropertyChanged("GekozenKassa"); }
        }
        private Employee gekozenemployee;
        public Employee GekozenEmployee
        {
            get { return gekozenemployee; }
            set { gekozenemployee = value; OnPropertyChanged("GekozenEmployee"); }
        }
        private DateTime from;
        public DateTime From
        {
            get { return from; }
            set { from = value; OnPropertyChanged("From"); }
        }
        private DateTime until;
        public DateTime Until
        {
            get { return until; }
            set { until = value; OnPropertyChanged("Until"); }
        }

        private List<IPage> startpage;
        public List<IPage> Startpage
        {
            get
            {
                if (startpage == null)
                    startpage = new List<IPage>();
                return startpage;
            }
        }
        public ICommand LogOff
        {
            get { return new RelayCommand(Logout); }
        }
        private async void Logout()
        {
            Register_Employee newLogin = new Register_Employee();
            newLogin.EmployeeID = GekozenEmployee;
            newLogin.From = From;
            newLogin.Until = DateTime.Now;
            newLogin.RegisterID = GekozenKassa;
            await SaveLogin(newLogin);
            token = null;
            ChangePage(new PageOneVM());
            MenuVisibility = false;
        }


        private List<IPage> pages;
        public List<IPage> Pages
        {
            get
            {
                if (pages == null)
                    pages = new List<IPage>();
                return pages;
            }
        }

        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }
        public void ToonRegister(Register reg)
        {
            GekozenKassa = reg;
        }
        public void ChangePage(IPage page)
        {
            CurrentPage = page;
        }
        public async Task<int> SaveLogin(Register_Employee newLogin)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/RegisterEmployee");
                string json = JsonConvert.SerializeObject(newLogin);
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
