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
        private const string URL = "http://localhost:20000/api";
        public string Name
        {
            get { return "New Account"; }
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
        private async void AddCustomerToDB()
        {
            await SaveCustomer(NewCust);
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
