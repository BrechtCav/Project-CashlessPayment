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
        #region Data
        //Datum van
        private Nullable<DateTime> fromdate;
        public Nullable<DateTime> FromDate
        {
            get{return fromdate;}
            set{fromdate = value; OnPropertyChanged("FromDate");}
        }
        //Datum tot
        private Nullable<DateTime> untildate;
        public Nullable<DateTime> UntilDate
        {
            get { return untildate; }
            set { untildate = value; OnPropertyChanged("UntilDate"); }
        }
        //Gekozen product
        private Product selectedproduct;
        public Product SelectedProduct
        {
            get { return selectedproduct; }
            set { selectedproduct = value; OnPropertyChanged("SelectedProduct"); }
        }
        //Gekozen kassa
        private Register selectedkassa;
        public Register SelectedKassa
        {
            get { return selectedkassa; }
            set { selectedkassa = value; OnPropertyChanged("SelectedKassa"); }
        }
        //kassalijst
        private List<Register> kassalist;
        public List<Register> KassaList
        {
            get { return kassalist; }
            set { kassalist = value; OnPropertyChanged("KassaList"); }
        }
        //productlijst
        private List<Product> productlist;
        public List<Product> ProductList
        {
            get { return productlist; }
            set { productlist = value; OnPropertyChanged("ProductList"); }
        }
        //Lijst met verkopen
        private List<Sale> resultaten;
        public List<Sale> Resultaten
        {
            get { return resultaten; }
            set { resultaten = value; OnPropertyChanged("Resultaten"); }
        }
        //Lijst Met gezochte resultaten
        private List<Sale> eindresultaat;
        public List<Sale> EindResultaat
        {
            get { return eindresultaat; }
            set { eindresultaat = value; OnPropertyChanged("EindResultaat"); }
        }
#endregion
        
        #region ICommands
        //ICommand Zoek
        public ICommand Zoek
        {
            get { return new RelayCommand(ZoekOpdracht); }
        }
#endregion

        #region Voids
        //Verkrijgen kassa's en producten en verkopen
        private async void Getlistsales()
        {
            await GetProducts();
            await GetRegisters();
            await GetSales();
        }
        //Method Zoeken
        private void ZoekOpdracht()
        {
            //Lijst Ophalen
            List<Sale> lijst = Resultaten;
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
        #endregion

        #region Tasks
        //Ophalen Sales
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
        //Ophalen Kassa's
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
        //Ophalen Producten
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
                    ProductList = sortedProduct.OrderBy(o => o.ProductName).ToList();
                    return ProductList;

                }
            }
            return null;
        }
        #endregion
    }
}