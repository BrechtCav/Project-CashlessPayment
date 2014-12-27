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

        //IsEnabled Kassalijst
        private bool btnwijzig;
        public bool BtnWijzig
        {
            get { return btnwijzig; }
            set { btnwijzig = value; OnPropertyChanged("BtnWijzig"); }
        }
        //IsEnabled Kassalijst
        private bool btnopslaan;
        public bool BtnOpslaan
        {
            get { return btnopslaan; }
            set { btnopslaan = value; OnPropertyChanged("BtnOpslaan"); }
        }
        //IsEnabled Kassalijst
        private bool btnannuleren;
        public bool BtnAnnuleren
        {
            get { return btnannuleren; }
            set { btnannuleren = value; OnPropertyChanged("BtnAnnuleren"); }
        }
        //IsEnabled Kassalijst
        private bool info;
        public bool Info
        {
            get { return info; }
            set { info = value; OnPropertyChanged("Info"); }
        }

        #endregion
        #region Data

        //IsEnabled Kassalijst
        private Customer selectedklant;
        public Customer SelectedKlant
        {
            get { return selectedklant; }
            set { selectedklant = value; OnPropertyChanged("SelectedKlant"); }
        }

        //IsEnabled Kassalijst
        private List<Customer> listklant;
        public List<Customer> ListKlant
        {
            get { return listklant; }
            set { listklant = value; OnPropertyChanged("ListKlant"); }
        }
        //IsEnabled Kassalijst
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { naam = value; OnPropertyChanged("Naam"); }
        }
        //IsEnabled Kassalijst
        private string adres;
        public string Adres
        {
            get { return adres; }
            set { adres = value; OnPropertyChanged("Adres"); }
        }
        //IsEnabled Kassalijst
        private string saldo;
        public string Saldo
        {
            get { return saldo; }
            set { saldo = value; OnPropertyChanged("Saldo"); }
        }
        //IsEnabled Kassalijst
        private byte[] image;
        public byte[] Image
        {
            get { return image; }
            set { image = value; OnPropertyChanged("Image"); }
        }
        #endregion
        #region ICommands


        public ICommand ToonKlant
        {
            get { return new RelayCommand(ToonKlantGegevens); }
        }

        public ICommand KlantWijzigen
        {
            get { return new RelayCommand(Wijzig); }
        }

        public ICommand KlantOpslaan
        {
            get { return new RelayCommand(Opslaan); }
        }

        public ICommand KlantAnnuleren
        {
            get { return new RelayCommand(Annuleren); }
        }
        #endregion
        #region Voids

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
        private void Wijzig()
        {
            KlantLijst = false;
            BtnWijzig = false;
            BtnAnnuleren = true;
            BtnOpslaan = true;
            Info = true;
        }
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
        private void Opslaan()
        {
            KlantLijst = false;
            BtnWijzig = false;
            BtnAnnuleren = true;
            BtnOpslaan = true;
            Info = true;
        }
        private async void GetListCustomers()
        {
            await GetCustomers();
        }

        #endregion
        #region Tasks

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
                    ListKlant = result;
                    return result;
                }
            }
            return null;
        }
        #endregion
    }
}
