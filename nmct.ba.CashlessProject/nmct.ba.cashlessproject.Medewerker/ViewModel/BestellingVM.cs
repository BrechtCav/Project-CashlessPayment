using be.belgium.eid;
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

namespace nmct.ba.cashlessproject.Medewerker.ViewModel
{
    class BestellingVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "Bestelling"; }
        }
        public BestellingVM()
        {
           if(ApplicationVM.token != null)
           {
               GetCategorieen();
               GetCustomers();
               KlantMelding = "";
               LoadedCustomer = null;
           }
        }
        #region Data
        //Geladen Customer van Database
        private Customer loadedcustomer;
        public Customer LoadedCustomer
        {
            get { return loadedcustomer; }
            set { loadedcustomer = value; OnPropertyChanged("LoadedCustomer"); }
        }
        //Saldo klant
        private double saldo;
        public double Saldo
        {
            get { return saldo; }
            set { saldo = value; OnPropertyChanged("Saldo"); }
        }
        //Aantal van een product
        private int amount = 1;
        public int Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged("Amount"); }
        }

        //Totaal van bestelling
        private double totaal = 0;
        public double Totaal
        {
            get { return totaal; }
            set { totaal = value; OnPropertyChanged("Totaal"); }
        }
        
        //Lijst met klanten
        public List<Customer> CustomersDB { get; set; }

        //Geselecteerde bestelling
        private ProductSale selectedproductsale;
        public ProductSale SelectedProductSale
        {
            get { return selectedproductsale; }
            set { selectedproductsale = value; OnPropertyChanged("SelectedProductSale"); }
        }

        //Melding klant
        private string klantmelding;
        public string KlantMelding
        {
            get { return klantmelding; }
            set { klantmelding = value; OnPropertyChanged("KlantMelding"); }
        }
        
        //Geselecteerd product
        private Product selectedproduct;
        public Product SelectedProduct
        {
            get { return selectedproduct; }
            set { selectedproduct = value; OnPropertyChanged("SelectedProduct"); }
        }
        
        //Lijst met producten
        private List<Product> productlijst;
        public List<Product> ProductLijst
        {
            get { return productlijst; }
            set { productlijst = value; OnPropertyChanged("ProductLijst"); }
        }

        //Bestellijst
        private List<ProductSale> listproductsale;
        public List<ProductSale> ListProductSale
        {
            get { return listproductsale; }
            set { listproductsale = value; OnPropertyChanged("ListProductSale"); }
        }
        //Lijst ProductSale
        List<ProductSale> PSList = new List<ProductSale>();

        //Lijst met Categorieën
        private List<Categorie> catlist;
        public List<Categorie> CatList
        {
            get { return catlist; }
            set { catlist = value; OnPropertyChanged("CatList"); }
        }
        //Geselecteerde categorie
        private Categorie selectedcategorie;
        public Categorie SelectedCategorie
        {
            get { return selectedcategorie; }
            set { selectedcategorie = value; OnPropertyChanged("SelectedCategorie"); }
        }

        #endregion
        #region ICommands


            
        //Icommand voor hoger aantal
        public ICommand AmountUp
        {
            get { return new RelayCommand(UpAmount); }
        }
            
        //ICommand voor ophalen producten
        public ICommand GetProductencbo
        {
            get { return new RelayCommand(GetProd); }
        }
        //ICommand voor lager aantal
        public ICommand AmountDown
        {
            get { return new RelayCommand(DownAmount); }
        }

        //ICommand voor een sale toe te voegen
        public ICommand Toevoegen
        {
            get { return new RelayCommand(VoegSaleToe); }
        }

        //ICommand voor sale te verwijderen
        public ICommand DeleteProductSale
        {
            get { return new RelayCommand(VerwijderProductSale); }
        }

        //ICommand voor bestelling te annuleren
        public ICommand BestellingAnnuleren
        {
            get { return new RelayCommand(Annuleren); }
        }
        //ICommand voor EID te lezen
        public ICommand EIDLezen
        {
            get { return new RelayCommand(IsAlLid); }
        }
        //ICommand voor EID te lezen
        public ICommand BestellingAfronden
        {
            get { return new RelayCommand(Afronden); }
        }
        #endregion
        #region Voids

        private async void Afronden()
        {
            if(LoadedCustomer != null)
            {
                if(PSList.Count >= 1)
                {
                    if(Totaal <= LoadedCustomer.Balance)
                    {
                        KlantMelding = "";

                        foreach(ProductSale sal in PSList)
                        {
                            Sale NewSale = new Sale();
                            NewSale.CustomerID = LoadedCustomer;
                            NewSale.ProductID = sal.ProductID;
                            NewSale.RegisterID = appvm.GekozenKassa;
                            NewSale.Timestamp = DateTime.Now;
                            NewSale.Totalprice = sal.Totalprice;
                            NewSale.Amount = sal.AmountPR;
                            await SaveSale(NewSale);
                        }
                        Transfer newTransfer = new Transfer();
                        newTransfer.Amount = Totaal;
                        newTransfer.Cust = LoadedCustomer;
                        newTransfer.Teken = 0;
                        await TransferMoney(newTransfer);
                        ListProductSale = new List<ProductSale>();
                        PSList = new List<ProductSale>();
                        Saldo = LoadedCustomer.Balance - Totaal;
                        Totaal = 0;
                    }
                    else
                    {
                        KlantMelding = "De klant heeft te weinig krediet op zijn kaart.";
                    }
                }
                else
                {
                    KlantMelding = "Gelieve producten te selecteren";
                }
            }
            else
            {
                KlantMelding = "Eerst kaart inlezen.";
            }
        }
        //Void ophalen klanten
        private async void GetCustomers()
        {
            int ListCust = await GetCustomersFromDB();
        }
        private async void GetCategorieen()
        {
            await GetCategories();
            await GetCustomersFromDB();
        }
        //void voor annuleren van bestelling
        private void Annuleren()
        {
            Totaal = 0;
            ListProductSale = null;
        }

        //Void voor sale toe te voegen
        private void VoegSaleToe()
        {
            //int iser voor te kijken of het product al bestaat
            int iser = 0;
            //Int algebeurd als het product al is toegevoegd
            int algebeurd = 0;
            if (SelectedProduct != null)
            {
                ListProductSale = new List<ProductSale>();
                //Wanneer er nog niets in de lijst PSList zit word er een nieuw product toegevoegd
                if (PSList.Count == 0)
                {
                    ProductSale newSale = new ProductSale();
                    newSale.ProductID = SelectedProduct;
                    newSale.AmountPR = Amount;
                    newSale.Totalprice = (double)(SelectedProduct.Price * Amount);
                    PSList.Add(newSale);
                    ListProductSale = PSList;
                    //Waarden terug zetten
                    Amount = 1;
                    SelectedProduct = null;
                    Totaal += newSale.Totalprice;
                }
                //Als er al iets in de lijst zit word elk element nagegaan om te kijken of het zelfde is als gekozenproduct anders word er een nieuw product toegevoegd
                else
                {
                    foreach (ProductSale sal in PSList)
                    {
                        if (algebeurd == 0)
                        {
                            if (sal.ProductID.Equals(SelectedProduct))
                            {
                                algebeurd = 1;
                                Totaal -= sal.Totalprice;
                                iser = 0;
                                sal.AmountPR += Amount;
                                sal.Totalprice = (double)(sal.ProductID.Price * sal.AmountPR);
                                Amount = 1;
                                SelectedProduct = null;
                                ListProductSale = PSList;
                                Totaal += sal.Totalprice;
                            }
                            else
                            {
                                iser = 1;
                            }
                        }
                    }
                    if (iser == 1)
                    {
                        ProductSale newSale = new ProductSale();
                        newSale.ProductID = SelectedProduct;
                        newSale.AmountPR = Amount;
                        newSale.Totalprice = (double)(SelectedProduct.Price * Amount);
                        PSList.Add(newSale);
                        ListProductSale = PSList;
                        Amount = 1;
                        SelectedProduct = null;
                        Totaal += newSale.Totalprice;
                    }
                }
            }
        }
        //Void voor het verwijderen van een sale
        private void VerwijderProductSale()
        {
            double total = 0;
            if (SelectedProductSale != null)
            {
                Totaal -= SelectedProductSale.Totalprice;
                ListProductSale.Remove(SelectedProductSale);
                foreach (ProductSale sal in PSList)
                {
                    if (sal.Equals(SelectedProductSale))
                    {
                        PSList.Remove(sal);
                    }
                }
                foreach (ProductSale sal in PSList)
                {
                    total += sal.Totalprice;
                }
                Totaal = total;
            }
            ListProductSale = new List<ProductSale>();
            ListProductSale = PSList;
        }


        //Void voor aantal omhoog
        public void UpAmount()
        {
            Amount++;
        }

        //Void voor aantal omlaag
        public void DownAmount()
        {
            if (Amount > 1)
            {
                Amount--;
            }
        }

        //Ophalen producten
        private async void GetProd()
        {
            await GetProductsbycategorie(SelectedCategorie.ID);
        }
        //Kijken of de eID al lid is 
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
                    KlantMelding = "";
                    if (Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_EID
                        || Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_FOREIGNER
                        || Reader.getCardType() == BEID_CardType.BEID_CARDTYPE_KIDS)
                    {

                        KlantMelding = "";
                        Customer test = Load_eid(Reader);

                        foreach (Customer nn in CustomersDB)
                        {
                            if (nn.NationalNumber.Equals(test.NationalNumber))
                            {
                                KlantMelding = "";
                                LoadedCustomer = new Customer();
                                LoadedCustomer = nn;
                                Saldo = LoadedCustomer.Balance;
                            }
                            else
                            {
                                KlantMelding = "Deze klant is nog geen lid.";
                            }
                        }
                    }
                    else
                    {
                        BEID_ReaderSet.releaseSDK();
                        KlantMelding = "Er is een fout bij het lezen van de kaart. Probeer opnieuw.";
                    }
                }
                else
                {
                    BEID_ReaderSet.releaseSDK();
                    KlantMelding = "Er is geen kaart gedetecteerd.";
                }

                BEID_ReaderSet.releaseSDK();
            }

            catch (BEID_ExNoReader ex)
            {
                Errorlog newError = new Errorlog();
                newError.Message = "Kaartlezer werd niet gevonden";
                newError.RegisterID = appvm.GekozenKassa;
                newError.Stacktrace = ex.StackTrace;
                newError.Timestamp = DateTime.Now;
                Error(newError);
                BEID_ReaderSet.releaseSDK();
                KlantMelding = "De kaartlezer werd niet gevonden.";
            }

        }
        private async void Error(Errorlog newError)
        {
            await SaveError(newError);
        }
        //Ophalen van data van eID
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
        #endregion
        #region Tasks

        //Ophalen Categorieen
        public async Task<List<Categorie>> GetCategories()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/Categorie");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Categorie> result = JsonConvert.DeserializeObject<List<Categorie>>(json).OrderBy(o => o.Name).ToList();
                    CatList = result;
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        //Ophalen producten per categorie.
        public async Task<List<Product>> GetProductsbycategorie(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/product/" + id);
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    ProductLijst = null;
                    string json = await response.Content.ReadAsStringAsync();
                    List<Product> sortedProduct = JsonConvert.DeserializeObject<List<Product>>(json);
                    ProductLijst = sortedProduct.OrderBy(o => o.ProductName).ToList();
                    return ProductLijst;

                }
            }
            return null;
        }
        //Ophalen lijst met klanten
        public async Task<int> GetCustomersFromDB()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/CustomerME");
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
        public async Task<int> SaveSale(Sale newSale)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/Sale");
                string json = JsonConvert.SerializeObject(newSale);
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
        public async Task<int> SaveError(Errorlog newError)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/Errorlog");
                string json = JsonConvert.SerializeObject(newError);
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
