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
using System.Drawing;
using System.Windows.Input;

namespace nmct.ba.CashlessProject.Klant.ViewModel
{
    class PageOneVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "First page"; }
        }
        public List<Customer> CustomersDB { get; set; }
        private async void GetCustomers()
        {
            int ListCust = await GetCustomersFromDB();
            if (ListCust == 1)
            {
                Loaded = 1;
            }
        }
        public PageOneVM()
        {
            GetCustomers();
        }


        private bool dbok = false;
        public bool DBOK
        {
            get { return dbok; }
            set { dbok = value; OnPropertyChanged("DBOK"); }
        }


        public int Loaded = 0;
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
        private string _eidaanwezig;
        public string EIDAanwezig
        {
            get { return _eidaanwezig; }
            set { _eidaanwezig = value; OnPropertyChanged("EIDAanwezig"); }
        }
        public ICommand EIDLezen
        {
            get { return new RelayCommand(IsAlLid); }
        }
        public void IsAlLid()
        {

            try
            {

                BEID_ReaderSet ReaderSet;
                ReaderSet = BEID_ReaderSet.instance();

                BEID_ReaderContext Reader;
                Reader = ReaderSet.getReader();


                if (Reader.isCardPresent())
                {
                    EIDAanwezig = "";
                    if (Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_EID
                        || Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_FOREIGNER
                        || Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_KIDS)
                    {

                        EIDAanwezig = "";
                        Customer test = Load_eid(Reader);

                        foreach (Customer nn in CustomersDB)
                        {
                            if(nn.NationalNumber.Equals(test.NationalNumber))
                            {
                                AccountVM.Customer = nn;
                                appvm.ChangePage(new AccountVM());
                            }
                            else
                            {
                                NewAccountVM.NewCust = test;
                                appvm.ChangePage(new NewAccountVM());
                            }
                        }
                    }
                    else
                    {
                        BEID_ReaderSet.releaseSDK();
                        EIDAanwezig = "Er is een fout bij het lezen van de kaart. Probeer opnieuw.";
                    }
                }

                BEID_ReaderSet.releaseSDK();
            }

            catch (BEID_Exception ex)
            {
                BEID_ReaderSet.releaseSDK();
                EIDAanwezig = "Gelieve uw eID in het voorziene toestel te steken.";
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
            IDCust.Address = doc.getStreet() + " " + doc.getZipCode() + " " + doc.getMunicipality();
            IDCust.Balance = 0;
            IDCust.Name = doc.getFirstName() + " " + doc.getSurname();
            IDCust.NationalNumber = doc.getNationalNumber().ToString();
            BEID_Picture picture;
            picture = card.getPicture();
            byte[] bytearray;
            bytearray = picture.getData().GetBytes();
            IDCust.Picture = bytearray;
            return IDCust;
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
                    DBOK = true;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

    }


}
