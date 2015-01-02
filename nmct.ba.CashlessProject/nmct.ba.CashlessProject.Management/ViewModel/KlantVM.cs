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
    class KlantVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "Klant"; }
        }
        public KlantVM()
        {
            if(ApplicationVM.token != null)
            {
                GetListCustomers();
                KlantLijst = true;
                BtnWijzig = false;
                BtnAnnuleren = false;
                BtnOpslaan = false;
                Info = false;
            }
        }
        #region Enabled


        //IsEnabled Kassalijst
        private bool klantlijst;
        public bool KlantLijst
        {
            get { return klantlijst; }
            set { klantlijst = value; OnPropertyChanged("KlantLijst"); }
        }

        //IsEnabled wijzig button
        private bool btnwijzig;
        public bool BtnWijzig
        {
            get { return btnwijzig; }
            set { btnwijzig = value; OnPropertyChanged("BtnWijzig"); }
        }
        //IsEnabled opslaan button
        private bool btnopslaan;
        public bool BtnOpslaan
        {
            get { return btnopslaan; }
            set { btnopslaan = value; OnPropertyChanged("BtnOpslaan"); }
        }
        //IsEnabled annuleren button
        private bool btnannuleren;
        public bool BtnAnnuleren
        {
            get { return btnannuleren; }
            set { btnannuleren = value; OnPropertyChanged("BtnAnnuleren"); }
        }
        //IsEnabled textboxen
        private bool info;
        public bool Info
        {
            get { return info; }
            set { info = value; OnPropertyChanged("Info"); }
        }

        #endregion

        #region Data

        //Geselecteerde klant
        private Customer selectedklant;
        public Customer SelectedKlant
        {
            get { return selectedklant; }
            set { selectedklant = value; OnPropertyChanged("SelectedKlant"); }
        }

        //lijst met klanten
        private List<Customer> listklant;
        public List<Customer> ListKlant
        {
            get { return listklant; }
            set { listklant = value; OnPropertyChanged("ListKlant"); }
        }
        //klant naam
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { naam = value; OnPropertyChanged("Naam"); }
        }
        //klant adres
        private string adres;
        public string Adres
        {
            get { return adres; }
            set { adres = value; OnPropertyChanged("Adres"); }
        }
        //klant saldo
        private string saldo;
        public string Saldo
        {
            get { return saldo; }
            set { saldo = value; OnPropertyChanged("Saldo"); }
        }
        //foutmelding 
        private string foutmelding;
        public string Foutmelding
        {
            get { return foutmelding; }
            set { foutmelding = value; OnPropertyChanged("Foutmelding"); }
        }
        // klant image
        private byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged("Image"); }
        }
        #endregion
        
        #region ICommands

        //ICommand tonen
        public ICommand ToonKlant
        {
            get { return new RelayCommand(ToonKlantGegevens); }
        }
        //ICommand wijzigen
        public ICommand KlantWijzigen
        {
            get { return new RelayCommand(Wijzig); }
        }
        //ICommand opslaan
        public ICommand KlantOpslaan
        {
            get { return new RelayCommand(Opslaan); }
        }
        //ICOmmand annuleren
        public ICommand KlantAnnuleren
        {
            get { return new RelayCommand(Annuleren); }
        }
        #endregion
        
        #region Voids
        //Tonen van gegevens gekozen klant
        private void ToonKlantGegevens()
        {
            if(SelectedKlant != null)
            {
                Naam = SelectedKlant.Name;
                Adres = SelectedKlant.Address;
                Saldo = SelectedKlant.Balance.ToString();
                Image = SelectedKlant.Picture;
                BtnWijzig = true;
            }
        }
        //Method voor wijzigen
        private void Wijzig()
        {
            KlantLijst = false;
            BtnWijzig = false;
            BtnAnnuleren = true;
            BtnOpslaan = true;
            Info = true;
        }
        //Method voor annuleren
        private void Annuleren()
        {
            Naam = "";
            Adres = "";
            Saldo = "";
            Image = null;
            SelectedKlant = null;
            KlantLijst = true;
            BtnWijzig = false;
            BtnAnnuleren = false;
            BtnOpslaan = false;
            Info = false;
        }
        //Method voor opslaan
        private async void Opslaan()
        {
            int ok = 0;
            //Kijken of naam en adres niet leeg zijn.
            if(Naam != "" && Adres != "")
            {
                SelectedKlant.Name = Naam;
                SelectedKlant.Address = Adres;
                await ChangeCustomer(SelectedKlant);
            }
            else
            {
                ok = 1;
                Foutmelding = "Gelieve alles in te vullen";
            }
            //
            if(Saldo != null)
            {
                Transfer newTranfer = new Transfer();
                newTranfer.Cust = SelectedKlant;
                double sal;
                bool issal = double.TryParse(Saldo, out sal);
                if(issal == true)
                {
                    if(SelectedKlant.Balance > sal)
                    {
                        newTranfer.Teken = 0;
                        newTranfer.Amount = SelectedKlant.Balance - sal;
                    }
                    else if(SelectedKlant.Balance < sal)
                    {
                        newTranfer.Teken = 1;
                        newTranfer.Amount = sal - SelectedKlant.Balance;
                    }
                    if(newTranfer.Teken == 0 || newTranfer.Teken == 1)
                    {
                        await TransferMoney(newTranfer);
                    }
                }
            }
            else
            {
                ok = 1;
                Foutmelding = "Gelieve een correct saldo in te geven";
            }
            if(ok == 0)
            {
                await GetCustomers();
                SelectedKlant = null;
                Naam = "";
                Adres = "";
                Saldo = "";
                Image = null;
                KlantLijst = true;
                BtnWijzig = false;
                BtnAnnuleren = false;
                BtnOpslaan = false;
                Info = false;
            }
        }
        //Async method voor klanten op te halen
        private async void GetListCustomers()
        {
            await GetCustomers();
        }

        #endregion
        
        #region Tasks
        //Klanten lijst ophalen
        public async Task<List<Customer>> GetCustomers()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/CustomerMA");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Customer> result = JsonConvert.DeserializeObject<List<Customer>>(json);
                    ListKlant = result.OrderBy(o => o.Name).ToList();
                    return result;
                }
            }
            return null;
        }
        //Klant opslaan
        public async Task<int> ChangeCustomer(Customer changedCustomer)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/customerMA");
                string json = JsonConvert.SerializeObject(changedCustomer);
                HttpResponseMessage response = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
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
        //Opslaan Transfer
        public async Task<int> TransferMoney(Transfer changedCustomer)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/TransferMA");
                string json = JsonConvert.SerializeObject(changedCustomer);
                HttpResponseMessage response = await client.PutAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
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
        #endregion
    }
}
