using be.belgium.eid;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace nmct.ba.CashlessProject.Klant.ViewModel
{
    class PageOneVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:25000/api";
        public string Name
        {
            get { return "First page"; }
        }
        public PageOneVM()
        {
            GetProductsbycategorie();
        }
        private string _intro = "Welkom bij KV Kortrijk";
        public string Intro
        {
            get { return _intro; }
            set { _intro = value; OnPropertyChanged("Intro"); }
        }
        private string _eidmelding = "Gelieve uw elektronische identiteitskaart in de lezer te steken";
        public string EidMelding
        {
            get { return _eidmelding; }
            set { _eidmelding = value; }
        }
        private string _eidaanwezig = "";
        public string EIDAanwezig
        {
            get { return _eidaanwezig; }
            set { _eidaanwezig = value; }
        }
        public ICommand EIDLezen
        {
            get { return new RelayCommand(IsLid); }
        }
        public void IsLid()
        {
            List<string> lijst = new List<string>();
            foreach (Customer cust in CustomersDB)
            {
                string nn = cust.NationalNumber;
                lijst.Add(nn);
            }
            Test(lijst);
        }
        public void Test(List<string> lijst)
        {

            try
            {

                BEID_ReaderSet ReaderSet;
                ReaderSet = BEID_ReaderSet.instance();

                BEID_ReaderContext Reader;
                Reader = ReaderSet.getReader();


                if (Reader.isCardPresent())
                {
                    if (Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_EID
                        || Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_FOREIGNER
                        || Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_KIDS)
                    {
                        Customer test = Load_eid(Reader);

                        foreach (string nn in lijst)
                        {
                            if (nn.Equals(test.NationalNumber))
                            {
                                Intro = "Gelukt";
                            }
                            else
                            {
                                Intro = "Niet Gelukt";
                            }
                        }
                    }
                }

                BEID_ReaderSet.releaseSDK();
            }

            catch (BEID_Exception ex)
            {
                BEID_ReaderSet.releaseSDK();
            }

        }
        private Customer Load_eid(BEID_ReaderContext Reader)
        {
            Customer IDCust = new Customer();
            BEID_EIDCard card;
            card = Reader.getEIDCard();
            if (card.isTestCard())
            {
                card.setAllowTestCard(true);
            }

            BEID_EId doc;
            doc = card.getID();
            IDCust.Address = doc.getStreet();
            IDCust.Balance = 0;
            IDCust.Name = doc.getFirstName() + " " + doc.getSurname();
            IDCust.NationalNumber = doc.getNationalNumber().ToString();
            IDCust.Picture = "1";
            return IDCust;
        }
        public async void GetProductsbycategorie()
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
                }
                else
                {
                    Intro = "Niet Gelukt 2";
                }
            }
        }
        public List<Customer> CustomersDB { get; set; }
    }


}
