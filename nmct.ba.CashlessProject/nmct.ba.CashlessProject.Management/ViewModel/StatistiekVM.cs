using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Data;
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
            if(ApplicationVM.token != null)
            {
                Getlistsales();
            }
        }
        private async void Getlistsales()
        {
            await GetProducts();
            await GetRegisters();
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
        private List<Product> productlist;
        public List<Product> ProductList
        {
            get { return productlist; }
            set { productlist = value; OnPropertyChanged("ProductList"); }
        }
        private List<Sale> resultaten;
        public List<Sale> Resultaten
        {
            get { return resultaten; }
            set { resultaten = value; OnPropertyChanged("Resultaten"); }
        }
        private List<Sale> eindresultaat;
        public List<Sale> EindResultaat
        {
            get { return eindresultaat; }
            set { eindresultaat = value; OnPropertyChanged("EindResultaat"); }
        }
        
        public ICommand Zoek
        {
            get { return new RelayCommand(ZoekOpdracht); }
        }
        private async void ZoekOpdracht()
        {
            List<Sale> lijst = await GetSales();
            if(SelectedProduct != null)
            {
                lijst = lijst.FindAll(s => s.ProductID.ID == selectedproduct.ID);
            }
            if(SelectedKassa != null)
            {
                lijst = lijst.FindAll(s => s.RegisterID.RegisterID == SelectedKassa.RegisterID);
            }
            if(FromDate != null)
            {
                lijst = lijst.FindAll(s => s.Timestamp >= FromDate);
            }
            if(UntilDate != null)
            {
                lijst = lijst.FindAll(s => s.Timestamp <= UntilDate);
            }
            EindResultaat = lijst;
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
                    Resultaten = result;
                    return result;
                }
            }
            return null;
        }
        public async Task<List<Register>> GetRegisters()
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
                    KassaList = result.OrderBy(o => o.RegisterName).ToList();
                    return KassaList;
                }
            }
            return null;
        }
        //Ophalen producten per categorie.
        public async Task<List<Product>> GetProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/product/");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    List<Product> prod = new List<Product>();
                    ProductList = null;
                    string json = await response.Content.ReadAsStringAsync();
                    List<Product> sortedProduct = JsonConvert.DeserializeObject<List<Product>>(json);
                    prod = sortedProduct.OrderBy(o => o.ProductName).ToList();
                    ProductList = prod;
                    return ProductList;

                }
            }
            return null;
        }

    }
}