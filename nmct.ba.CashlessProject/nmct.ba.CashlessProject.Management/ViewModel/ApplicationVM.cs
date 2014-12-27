using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Thinktecture.IdentityModel.Client;

namespace nmct.ba.CashlessProject.Management.ViewModel
{
    class ApplicationVM : ObservableObject
    {
        public static TokenResponse token = null;
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        public ApplicationVM()
        {
            StartPages.Add(new LoginVM());
            Pages.Add(new PageOneVM());
            Pages.Add(new MedewerkerVM());
            Pages.Add(new KassaVM());
            Pages.Add(new KlantVM());
            Pages.Add(new StatistiekVM());
            // Add other pages

            CurrentPage = StartPages[0];
        }
        private string organisatie = "";
        public string Organisatie
        {
            get { return organisatie; }
            set { organisatie = value; OnPropertyChanged("Organisatie"); }
        }
        private string tijd = "";
        public string Tijd
        {
            get { return tijd; }
            set { tijd = value; OnPropertyChanged("Tijd"); }
        }
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        int test = 0;
        public void klok()
        {
            dispatcherTimer.Tick += new EventHandler(this.kloktik);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void kloktik(object sender, EventArgs e)
        {
            test +=1;
            string dag = DateTimeFormatInfo.CurrentInfo.GetDayName(DateTime.Now.DayOfWeek);
            Tijd = char.ToUpper(dag[0]) + dag.Substring(1) +" " + DateTime.Now.ToString();
        }
        public async void GetDBInfo()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:7695/api/DatabaseInfo");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync(); 
                    JsonConvert.DeserializeObject<string>(json);
                    Organisatie = JsonConvert.DeserializeObject<string>(json);
                }
            }
        }

        private object currentPage;
        public object CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
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


        private bool menuvisibility = false;
        public bool MenuVisibility
        {
            get { return menuvisibility; }
            set { menuvisibility = value; OnPropertyChanged("MenuVisibility"); }
        }

        private List<IPage> startpages;
        public List<IPage> StartPages
        {
            get
            {
                if (startpages == null)
                    startpages = new List<IPage>();
                return startpages;
            }
        }

        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }
        public ICommand LogOff
        {
            get { return new RelayCommand(Logout); }
        }
        private void Logout()
        {
            token = null;
            ChangePage(new LoginVM());
            MenuVisibility = false;
            Organisatie = "Organisatie: ";
        }
        public void ChangePage(IPage page)
        {
            CurrentPage = page;
        }
    }
}
