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

namespace nmct.ba.CashlessProject.Klant.ViewModel
{
    class NewAccountVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "New Account"; }
        }
        public NewAccountVM()
        {
            JaEnabled = true;
        }
        public static Customer NewCust { get; set; }

        public ICommand Menu
        {
            get { return new RelayCommand(BackToMenu); }
        }
        public ICommand AddCustomer
        {
            get { return new RelayCommand(AddCustomerToDB); }
        }
        private void BackToMenu()
        {
            appvm.ChangePage(new PageOneVM());
        }
        private bool jaenabled;
        public bool JaEnabled
        {
            get { return jaenabled; }
            set { jaenabled = value; OnPropertyChanged("JaEnabled"); }
        }
        private string melding;
        public string Melding
        {
            get { return melding; }
            set { melding = value; OnPropertyChanged("Melding"); }
        }
        public List<Customer> CustomersDB { get; set; }
        private async void AddCustomerToDB()
        {
            Melding = "";
            await SaveCustomer(NewCust);
            await GetCustomersFromDB();
            foreach(Customer cust in CustomersDB)
            {
                if(cust.NationalNumber.Equals(NewCust.NationalNumber))
                {
                    AccountVM.SelectedCustomer = cust;
                    SaldoVM.SelectedCustomer = cust;
                    appvm.ChangePage(new AccountVM());
                }
                else
                {
                    Melding = "Gelieve terug te keren naar het menu en opnieuw te proberen.";
                    JaEnabled = false;
                }
            }
        }
        public async Task<int> GetCustomersFromDB()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/Customer");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Customer> result = JsonConvert.DeserializeObject<List<Customer>>(json);
                    CustomersDB = result;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        public async Task<int> SaveCustomer(Customer newCustomer)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/Customer/");
                string json = JsonConvert.SerializeObject(newCustomer);
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
