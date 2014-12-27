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

namespace nmct.ba.CashlessProject.Management.ViewModel
{
    class StatistiekVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "Statistiek"; }
        }
        public StatistiekVM()
        {
        }
        private async void test()
        {
            await GetList();
            ZoekOpdracht();
        }
        private Nullable<DateTime> fromdate;
        public Nullable<DateTime> FromDate
        {
            get{return fromdate;}
            set{fromdate = value; OnPropertyChanged("FromDate");}
        }
        private Nullable<DateTime> untildate;
        public Nullable<DateTime> UntilDate
        {
            get { return untildate; }
            set { untildate = value; OnPropertyChanged("UntilDate"); }
        }
        private Product selectedproduct;
        public Product SelectedProduct
        {
            get { return selectedproduct; }
            set { selectedproduct = value; OnPropertyChanged("SelectedProduct"); }
        }
        private Register selectedkassa;
        public Register SelectedKassa
        {
            get { return selectedkassa; }
            set { selectedkassa = value; OnPropertyChanged("SelectedKassa"); }
        }
        private List<Register> kassalist;
        public List<Register> KassaList
        {
            get { return kassalist; }
            set { kassalist = value; OnPropertyChanged("KassaList"); }
        }
        private List<Sale> resultaten;
        public List<Sale> Resultaten
        {
            get { return resultaten; }
            set { resultaten = value; OnPropertyChanged("Resultaten"); }
        }
        
        public ICommand Zoek
        {
            get { return new RelayCommand(test); }
        }
        private async void ZoekOpdracht()
        {
            int Productid;
            int Kassaid;
            Nullable<DateTime> From;
            Nullable<DateTime> Until;
            if(SelectedProduct != null)
            {
                Productid = SelectedProduct.ID;
            }
            else
            {
                Productid = 0;
            }
            if(SelectedKassa != null)
            {
                Kassaid = SelectedKassa.RegisterID;
            }
            else
            {
                Kassaid = 0;
            }
            if(FromDate != null)
            {
                From = FromDate;
            }
            else
            {
                From = null;
            }
            if(UntilDate != null)
            {
                Until = UntilDate;
            }
            else
            {
                Until = null;
            }
            List<Sale> saleslist =  await GetSales();
            foreach(Sale sa in saleslist)
            {
                    Resultaten.Add(sa);
                
            }
        }
        //Ophalen producten per categorie.
        public async Task<List<Sale>> GetSales()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/sale/");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Resultaten = null;
                    string json = await response.Content.ReadAsStringAsync();
                    List<Sale> result = JsonConvert.DeserializeObject<List<Sale>>(json);
                    return result;
                }
            }
            return null;
        }
        public async Task<List<Register>> GetList()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/register");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Register> result = JsonConvert.DeserializeObject<List<Register>>(json);
                    KassaList = result;
                    return result;
                }
            }
            return null;
        }

    }
}