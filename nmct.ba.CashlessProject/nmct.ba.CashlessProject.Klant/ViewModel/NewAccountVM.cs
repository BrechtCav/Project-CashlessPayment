using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace nmct.ba.CashlessProject.Klant.ViewModel
{
    class NewAccountVM : ObservableObject, IPage
    {
        private const string URL = "http://localhost:19451/api";

        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        public string Name
        {
            get { return "New Account"; }
        }
        private Customer newcust;
        public Customer NewCust
        {
            get { return newcust; }
            set { newcust = value; }
        }

        public async Task<int> SaveCustomer(int newCustomer)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/Customer");
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
