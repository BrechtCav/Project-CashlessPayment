using GalaSoft.MvvmLight.CommandWpf;
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
    class PageOneVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "Producten"; }
        }
        public PageOneVM()
        {
            //Categorieën laden als er een token aanwezig is
            if (ApplicationVM.token != null)
            {
                GetCat();
                CategorieLijst = true;
                productlijst = false;
                NieuwProduct = true;
                WijzigProduct = false;
                VerwijderProduct = false;
                OpslaanProduct = false;
                AnnulerenProduct = false;
            }
        }
        //Toggle voor Opslaan
        int NieuwWijzigProductToggle = 0;
        #region Enabled

        //IsEnabled cboCategorie
        private bool categorielijst;
        public bool CategorieLijst
        {
            get { return categorielijst; }
            set { categorielijst = value; OnPropertyChanged("CategorieLijst"); }
        }

        //IsEnabled lstProducten
        private bool productlijst;
        public bool Productlijst
        {
            get { return productlijst; }
            set { productlijst = value; OnPropertyChanged("Productlijst"); }
        }

        //IsEnabled btnNiewProduct
        private bool nieuwproduct;
        public bool NieuwProduct
        {
            get { return nieuwproduct; }
            set { nieuwproduct = value; OnPropertyChanged("NieuwProduct"); }
        }

        //IsEnabled btnWijzigProduct
        private bool wijzigproduct;
        public bool WijzigProduct
        {
            get { return wijzigproduct; }
            set { wijzigproduct = value; OnPropertyChanged("WijzigProduct"); }
        }

        //IsEnabled OpslaandProduct
        private bool opslaanproduct;
        public bool OpslaanProduct
        {
            get { return opslaanproduct; }
            set { opslaanproduct = value; OnPropertyChanged("OpslaanProduct"); }
        }

        //IsEnabled btnAnnulerenProduct
        private bool annulerenproduct;
        public bool AnnulerenProduct
        {
            get { return annulerenproduct; }
            set { annulerenproduct = value; OnPropertyChanged("AnnulerenProduct"); }
        }

        //IsEnabled btnVerwijderenProduct
        private bool verwijderproduct;
        public bool VerwijderProduct
        {
            get { return verwijderproduct; }
            set { verwijderproduct = value; OnPropertyChanged("VerwijderProduct"); }
        }

        //IsEnabled txtnaam, txtprijs, cbocategorieproduct
        private bool infoproduct;
        public bool InfoProduct
        {
            get { return infoproduct; }
            set { infoproduct = value; OnPropertyChanged("InfoProduct"); }
        }

        #endregion


        #region  Data
        //Lijst met producten per categorie
        private List<Product> _producten;
        public List<Product> Producten
        {
            get { return _producten; }
            set { _producten = value; OnPropertyChanged("Producten"); }
        }

        //GekozenProduct
        private Product _gekozenproduct;
        public Product GekozenProduct
        {
            get { return _gekozenproduct; }
            set { _gekozenproduct = value; OnPropertyChanged("GekozenProduct"); }
        }

        //Lijst met categorieen
        private List<Categorie> categorie;
        public List<Categorie> Categorie
        {
            get { return categorie; }
            set { categorie = value; OnPropertyChanged("Categorie"); }
        }
        //Gekozen Categorie
        private Categorie productcategorie = null;
        public Categorie ProductCategorie
        {
            get { return productcategorie; }
            set { productcategorie = value; OnPropertyChanged("ProductCategorie"); }
        }

        //Gekozen productnaam
        private string productnaam = null;
        public string ProductNaam
        {
            get { return productnaam; }
            set { productnaam = value; OnPropertyChanged("ProductNaam"); }
        }
        //Gekozen productprijs
        private string productprijs = null;
        public string ProductPrijs
        {
            get { return productprijs; }
            set { productprijs = value; OnPropertyChanged("ProductPrijs"); }
        }
        //Foutmelding
        private string foutmelding = null;
        public string FoutMelding
        {
            get { return foutmelding; }
            set { foutmelding = value; OnPropertyChanged("FoutMelding"); }
        }

        //Product Categorie
        private List<Categorie> categorieproductlist;
        public List<Categorie> CategorieProductList
        {
            get { return categorieproductlist; }
            set { categorieproductlist = value; OnPropertyChanged("CategorieProductList"); }
        }

        //Product Categorie
        private Categorie categorieproduct = null;
        public Categorie CategorieProduct
        {
            get { return categorieproduct; }
            set { categorieproduct = value; OnPropertyChanged("CategorieProduct"); }
        }

        #endregion

        #region ICommands
        //ICommand voor ophalen producten volgens categorie
        public ICommand GetProductencbo
        {
            get { return new RelayCommand(Getprod); }
        }

        //ICommand voor nieuwproduct
        public ICommand NieuwProductButton
        {
            get { return new RelayCommand(NiewProduct); }
        }

        //ICommand voor wijzigen van product
        public ICommand WijzigProductButton
        {
            get { return new RelayCommand(WijzigenProduct); }
        }

        //ICommand voor opslaan product
        public ICommand OpslaanProductenButton
        {
            get { return new RelayCommand(ProductOpslaan); }
        }

        //ICommand voor annuleren product
        public ICommand AnnulerenProductButton
        {
            get { return new RelayCommand(ProductAnnuleren); }
        }

        //ICommand voor verwijderen product
        public ICommand VerwijderGekozenProduct
        {
            get { return new RelayCommand(DelProduct); }
        }

        //ICommand voor lijst tonen
        public ICommand ToonGekozenProductlst
        {
            get { return new RelayCommand(ToonGekozenProduct); }
        }

        #endregion

        #region Voids
        //Verkrijgen Categorien
        private async void GetCat()
        {
            await GetCategories();
        }

        //Verkrijgen Producten
        private async void Getprod()
        {
            if (ProductCategorie != null)
            {
                await GetProductsbycategorie(ProductCategorie.ID);
                Productlijst = true;
            }
        }
        //Verwijderen producten
        private async void DelProduct()
        {
            await DeleteProduct(GekozenProduct);
            await GetProductsbycategorie(ProductCategorie.ID);
            VerwijderProduct = false;
        }
        //Click Actie Nieuwproduct
        private void NiewProduct()
        {
            //Leegmaken van de velden en disablen en enablen van de juiste knoppen
            NieuwWijzigProductToggle = 0;
            ProductNaam = "";
            ProductPrijs = "";
            CategorieLijst = false;
            Productlijst = false;
            CategorieProduct = null;
            InfoProduct = true;
            OpslaanProduct = true;
            AnnulerenProduct = true;
            NieuwProduct = false ;
            WijzigProduct = false;
            VerwijderProduct = false;
        }
        //Click Actie WijzigProduct
        private void WijzigenProduct()
        {
            //Leegmaken van de velden en disablen en enablen van de juiste knoppen
            NieuwWijzigProductToggle = 1;
            CategorieLijst = false;
            Productlijst = false;
            InfoProduct = true;
            OpslaanProduct = true;
            AnnulerenProduct = true;
            NieuwProduct = false;
            WijzigProduct = false;
            VerwijderProduct = false;
        }
        //Click Actie Product Opslaan
        private async void ProductOpslaan()
        {
            //Ok = 0 wanneer er geen foutmeldingen zijn bij het toevoegen of wijzigen van een product
            int ok = 0;
            //Toggle voor te weten of het wijzigen of nieuw product is.
            if(NieuwWijzigProductToggle == 0)
            {
                //Kijken of alles ingevuld is.
                if(CategorieProduct != null && ProductNaam != "" && ProductPrijs != "")
                {
                    Product ProductNieuw = new Product();
                    string naam = ProductNaam;
                    ProductNieuw.Categorie = CategorieProduct.ID;
                    ProductNieuw.ProductName = naam;
                    //Kijken of de ingevulde prijs in textbox effectief een double is en . vervangen naar ,
                    string prijs = ProductPrijs.Replace(".", ",");
                    double price;
                    bool isprice = double.TryParse(prijs, out price);
                    if (isprice == true)
                    {
                        ProductNieuw.Price = price;
                        int id = await SaveProduct(ProductNieuw);
                        //Als er een fout is bij het opslaan volgt er een foutmelding
                        if(id == 0)
                        {
                            FoutMelding = "Probeer opnieuw";
                        }
                        //Juist zetten van cbocategorie
                        foreach (Categorie cat in Categorie)
                        {
                            if (cat.ID.Equals(ProductNieuw.Categorie))
                            {
                                ProductCategorie = cat;
                            }
                        }
                        //opnieuw productlijst ophalen.
                        await GetProductsbycategorie(ProductNieuw.Categorie);
                    }
                    //Foutmeldingen voor foute ingaves.
                    else
                    {
                        FoutMelding = "Gelieve een getal in te geven";
                        ok = 1;
                    }
                }
                else
                {
                    ok = 1;
                    if(CategorieProduct == null && ProductNaam == "" && ProductPrijs == "")
                    {
                        FoutMelding = "Gelieve correcte info in te geven";
                    }
                    else if(CategorieProduct == null)
                    {
                        FoutMelding = "Gelieve een categorie te kiezen";
                    }
                    else if(ProductNaam == "")
                    {
                        FoutMelding = "Gelieve een correcte naam in te geven";
                    }
                    else if(ProductPrijs == "")
                    {
                        FoutMelding = "Gelieve een correcte prijs te kiezen";
                    }
                }
            }
            else if(NieuwWijzigProductToggle == 1)
            {
                if (CategorieProduct != null && ProductNaam != "" && ProductPrijs != "")
                {
                    Product GewijzigdProduct = GekozenProduct;
                    string naam = ProductNaam;
                    GewijzigdProduct.Categorie = CategorieProduct.ID;
                    string prijs = ProductPrijs.Replace(".", ",");
                    double price;
                    bool isprice = double.TryParse(prijs, out price);
                    GewijzigdProduct.ProductName = naam;
                    if (isprice == true)
                    {
                        GewijzigdProduct.Price = price;
                        int id = await ChangeProduct(GewijzigdProduct);
                        if (id == 0)
                        {
                            FoutMelding = "Probeer opnieuw";
                        }
                        foreach (Categorie cat in Categorie)
                        {
                            if (cat.ID.Equals(GewijzigdProduct.Categorie))
                            {
                                ProductCategorie = cat;
                            }
                        }
                        await GetProductsbycategorie(GewijzigdProduct.Categorie);
                    }
                    else
                    {
                        FoutMelding = "Gelieve een getal in te geven";
                        ok = 1;
                    }
                }
                else
                {
                    ok = 1;
                    if (CategorieProduct == null && ProductNaam == "" && ProductPrijs == "")
                    {
                        FoutMelding = "Gelieve correcte info in te geven";
                    }
                    else if (CategorieProduct == null)
                    {
                        FoutMelding = "Gelieve een categorie te kiezen";
                    }
                    else if (ProductNaam == "")
                    {
                        FoutMelding = "Gelieve een correcte naam in te geven";
                    }
                    else if (ProductPrijs == "")
                    {
                        FoutMelding = "Gelieve een correcte prijs te kiezen";
                    }
                }
            }
            //Als er geen foutmeldingen zijn, alles in xaml enablen of disablen
            if (ok == 0)
            {
                FoutMelding = "";
                ProductNaam = "";
                ProductPrijs = "";
                CategorieProduct = null;
                CategorieLijst = true;
                Productlijst = true;
                InfoProduct = false;
                OpslaanProduct = false;
                AnnulerenProduct = false;
                NieuwProduct = true;
                WijzigProduct = false;
            }

        }
        //Click Actie bij annuleren
        private void ProductAnnuleren()
        {
            FoutMelding = "";
            ProductNaam = "";
            ProductPrijs = "";
            CategorieProduct = null;
            CategorieLijst = true;
            Productlijst = true;
            InfoProduct = false;
            OpslaanProduct = false;
            AnnulerenProduct = false;
            NieuwProduct = true;
            WijzigProduct = false;
            GekozenProduct = null;
        }


        //Product in textboxen tonen bij keuze in productlijst
        private void ToonGekozenProduct()
        {
            if (GekozenProduct != null)
            {
                VerwijderProduct = true;
                WijzigProduct = true;
                ProductNaam = GekozenProduct.ProductName;
                ProductPrijs = GekozenProduct.Price.ToString();
                foreach (Categorie cat in CategorieProductList)
                {
                    if (cat.ID.Equals(GekozenProduct.Categorie))
                    {
                        CategorieProduct = cat;
                    }
                }
            }
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
                    Categorie = result;
                    CategorieProductList = result;
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
                    Producten = null;
                    string json = await response.Content.ReadAsStringAsync();
                    List<Product> sortedProduct= JsonConvert.DeserializeObject<List<Product>>(json);
                    Producten = sortedProduct.OrderBy(o => o.ProductName).ToList();
                    return Producten;

                }
            }
            return null;
        }
        //Opslaan Product

        public async Task<int> SaveProduct(Product newProduct)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/Product");
                string json = JsonConvert.SerializeObject(newProduct);
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
        //Wijzigen Product
        public async Task<int> ChangeProduct(Product changeProduct)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/Product");
                string json = JsonConvert.SerializeObject(changeProduct);
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
        //Verwijderen Product
        public async Task<int> DeleteProduct(Product delProd)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/Product/" + delProd.ID);
                HttpResponseMessage response = await client.DeleteAsync(url);
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