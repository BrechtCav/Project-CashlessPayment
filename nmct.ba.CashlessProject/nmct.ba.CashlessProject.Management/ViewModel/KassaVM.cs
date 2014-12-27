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
    class KassaVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "Kassa"; }
        }
        public KassaVM()
        {
            if(ApplicationVM.token != null)
            {
                GetKassaList();
            }
        }
        #region Enabled


        //IsEnabled Kassalijst
        private bool kassalijst = true;
        public bool KassaLijst
        {
            get { return kassalijst; }
            set { kassalijst = value; OnPropertyChanged("KassaLijst"); }
        }
        //IsEnabled Kassalijst
        private bool kassanaam = false;
        public bool KassaNaam
        {
            get { return kassanaam; }
            set { kassanaam = value; OnPropertyChanged("KassaNaam"); }
        }
        //IsEnabled Kassalijst
        private bool kassalocatie = false;
        public bool KassaLocatie
        {
            get { return kassalocatie; }
            set { kassalocatie = value; OnPropertyChanged("KassaLocatie"); }
        }
        //IsEnabled Kassalijst
        private bool kassatoestel = false;
        public bool KassaToestel
        {
            get { return kassatoestel; }
            set { kassatoestel = value; OnPropertyChanged("KassaToestel"); }
        }
        //IsEnabled Kassalijst
        private bool kassaaanmeldlijst = true;
        public bool KassaAanmeldLijst
        {
            get { return kassaaanmeldlijst; }
            set { kassaaanmeldlijst = value; OnPropertyChanged("KassaAanmeldLijst"); }
        }


        #endregion
        #region Data

        // Kassalijst
        private Register gekozenkassa;
        public Register GekozenKassa
        {
            get { return gekozenkassa; }
            set { gekozenkassa = value; OnPropertyChanged("GekozenKassa"); }
        }
        private List<Register> listkassa;
        public List<Register> ListKassa
        {
            get { return listkassa; }
            set { listkassa = value; OnPropertyChanged("ListKassa"); }
        }
        // naam
        private string naam;
        public string Naam
        {
            get { return naam; }
            set { naam = value; OnPropertyChanged("Naam"); }
        }
        // locatie
        private string locatie;
        public string Locatie
        {
            get { return locatie; }
            set { locatie = value; OnPropertyChanged("Locatie"); }
        }
        // toestel
        private string toestel;
        public string Toestel
        {
            get { return toestel; }
            set { toestel = value; OnPropertyChanged("Toestel"); }
        }
        //List aanmeldingen Aanmeldlijst
        private List<Register_Employee> aanmeldlijst;
        public List<Register_Employee> Aanmeldlijst
        {
            get { return aanmeldlijst; }
            set { aanmeldlijst = value; OnPropertyChanged("Aanmeldlijst"); }
        }

        #endregion
        #region ICommands
        

        public ICommand  ToonKassa
        {
            get { return new RelayCommand(KassaTonen); }
        }
        #endregion
        #region Voids

        private async void KassaTonen()
        {
            Naam = GekozenKassa.RegisterName;
            Locatie = GekozenKassa.Location;
            Toestel = GekozenKassa.Device;
            await GetListRegEmp(GekozenKassa.RegisterID);
        }
        private async void GetKassaList()
        {
            await GetList();
        }
        #endregion
        #region Tasks

        public async Task<List<Register_Employee>> GetListRegEmp(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/registeremployee/" + id);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Register_Employee> result = JsonConvert.DeserializeObject<List<Register_Employee>>(json);
                    Aanmeldlijst = result;

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
                    ListKassa = result;
                    return result;
                }
            }
            return null;
        }

        #endregion
    }
}
