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
    class MedewerkerVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "Medewerker"; }
        }
        
        public MedewerkerVM()
        {
            if(ApplicationVM.token != null)
            {
                GetEmployeeList();
                LijstEnable = true;
                NieuwEnable = true;
                WijzigEnable = false;
                OpslaanAnnulerenEnable = false;
                Verwijderenable = false;
                TXTEnable = false;
            }
        }
        #region Enabled

        //IsEnabled Lijst medewerkers
        private bool lijstenable;
        public bool LijstEnable
        {
            get { return lijstenable; }
            set { lijstenable = value; OnPropertyChanged("LijstEnable"); }
        }

        //IsEnabled btn nieuw
        private bool nieuwenable;
        public bool NieuwEnable
        {
            get { return nieuwenable; }
            set { nieuwenable = value; OnPropertyChanged("NieuwEnable"); }
        }


        //IsEnabled btn wijzig
        private bool wijzigenable;
        public bool WijzigEnable
        {
            get { return wijzigenable; }
            set { wijzigenable = value; OnPropertyChanged("WijzigEnable"); }
        }

        //IsEnabled btns annuleren opslaan
        private bool opslaanannulerenenable;
        public bool OpslaanAnnulerenEnable
        {
            get { return opslaanannulerenenable; }
            set { opslaanannulerenenable = value; OnPropertyChanged("OpslaanAnnulerenEnable"); }
        }


        //IsEnabled btn verwijder
        private bool verwijderenable;
        public bool Verwijderenable
        {
            get { return verwijderenable; }
            set { verwijderenable = value; OnPropertyChanged("Verwijderenable"); }
        }

        //IsEnabled txt fields
        private bool txtenable;
        public bool TXTEnable
        {
            get { return txtenable; }
            set { txtenable = value; OnPropertyChanged("TXTEnable"); }
        }






        #endregion

        #region Data
        //Wijzigen of nieuw
        int ToggleWijzigNieuw;
        // Geselecteerde medewerker
        private Employee selectedemployee = null;
        public Employee SelectedEmployee
        {
            get { return selectedemployee; }
            set { selectedemployee = value; OnPropertyChanged("SelectedEmployee"); }
        }
        //Lijst Medewerkers
        private List<Employee> listemployees;
        public List<Employee> ListEmployees
        {
            get { return listemployees; }
            set { listemployees = value; OnPropertyChanged("ListEmployees"); }
        }
        //Name Medewerker
        private string employeename;
        public string EmployeeName
        {
            get { return employeename; }
            set { employeename = value; OnPropertyChanged("EmployeeName"); }
        }

        //Adres Medewerker
        private string employeeadres;
        public string EmployeeAdres
        {
            get { return employeeadres; }
            set { employeeadres = value; OnPropertyChanged("EmployeeAdres"); }
        }

        //Mail Medewerker
        private string employeeemail;
        public string EmployeeEmail
        {
            get { return employeeemail; }
            set { employeeemail = value; OnPropertyChanged("EmployeeEmail"); }
        }

        //Nummer Medewerker
        private string employeetel;
        public string EmployeeTel
        {
            get { return employeetel; }
            set { employeetel = value; OnPropertyChanged("EmployeeTel"); }
        }
        //Foutmelding
        private string foutmelding;
        public string FoutMelding
        {
            get { return foutmelding; }
            set { foutmelding = value; OnPropertyChanged("FoutMelding"); }
        }

        #endregion

        #region ICommands


        //ICommand Nieuw
        public ICommand btnNieuw
        {
            get { return new RelayCommand(NieuwMedewerker); }
        }


        //ICommand Wijzigen
        public ICommand btnWijzig
        {
            get { return new RelayCommand(WijzigMedewerker); }
        }
        //ICommand Opslaan
        public ICommand btnOpslaan
        {
            get { return new RelayCommand(MedewerkerOpslaan); }
        }
        //ICommand Annuleren
        public ICommand btnAnnuleren
        {
            get { return new RelayCommand(MedewerkerAnnuleren); }
        }
        //ICommand verwijderen
        public ICommand btnVerwijder
        {
            get { return new RelayCommand(MedewerkerVerwijderen); }
        }


        //ICommand voor tonen info gekozen medewerker
        public ICommand ToonGekozenMedewerker
        {
            get { return new RelayCommand(ToonMedewerker); }
        }


        #endregion

        #region Voids
        //Method Tonen medewerker info
        private void ToonMedewerker()
        {
            if(SelectedEmployee != null)
            {
                Verwijderenable = true;
                WijzigEnable = true;
                EmployeeAdres = SelectedEmployee.Address;
                EmployeeEmail = SelectedEmployee.Email;
                EmployeeName = SelectedEmployee.EmployeeName;
                EmployeeTel = SelectedEmployee.Phone;
            }
        }
        //Method ophalen medewerkerlijst
        private async void GetEmployeeList()
        {
            await GetEmployees();
        }
        //Method Nieuwe Medewerker
        private void NieuwMedewerker()
        {
            ToggleWijzigNieuw = 0;
            EmployeeAdres = "";
            EmployeeEmail = "";
            EmployeeName = "";
            EmployeeTel = "";
            SelectedEmployee = null;
            LijstEnable = false;
            WijzigEnable = false;
            NieuwEnable = false;
            OpslaanAnnulerenEnable = true;
            Verwijderenable = false;
            TXTEnable = true;
        }
        //Method Medewerker wijzigen
        private void WijzigMedewerker()
        {
            ToggleWijzigNieuw = 1;
            LijstEnable = false;
            WijzigEnable = false;
            NieuwEnable = false;
            OpslaanAnnulerenEnable = true;
            Verwijderenable = false;
            TXTEnable = true;
        }
        //Kijken of wat er in txtMail is ingevuld wel een geldig mail account is.
        bool IsMail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        //Method Opslaan Medewerker
        private async void MedewerkerOpslaan()
        {
            int fout = 0;
            //Als er een nieuwe medewerker is
            if(ToggleWijzigNieuw == 0)
            {
                if(EmployeeAdres != "" && EmployeeEmail != "" && EmployeeName != "" && EmployeeTel != "")
                {
                    Employee nieuwemployee = new Employee();
                    nieuwemployee.Address = EmployeeAdres;
                    nieuwemployee.EmployeeName = EmployeeName;
                    nieuwemployee.Phone = EmployeeTel;
                    bool mail = IsMail(EmployeeEmail);
                    if(mail == true)
                    {
                        nieuwemployee.Email = EmployeeEmail;
                        await SaveEmployee(nieuwemployee);
                        GetEmployeeList();
                    }
                    else
                    {
                        fout = 1;
                        FoutMelding = "Gelieve een juist mail adres in te geven.";
                    }    
                }
                else
                {
                    fout = 1;
                    FoutMelding = "Gelieve correcte gegevenss in te geven.";
                }
            }
            //Als er gewijzigd word
            else if(ToggleWijzigNieuw == 1)
            {
                if (EmployeeAdres != "" && EmployeeEmail != "" && EmployeeName != "" && EmployeeTel != "")
                {
                Employee emp = SelectedEmployee;
                    emp.Address = EmployeeAdres;
                    emp.EmployeeName = EmployeeName;
                    emp.Phone = EmployeeTel;
                    bool mail = IsMail(EmployeeEmail);
                    if(mail == true)
                    {
                        emp.Email = EmployeeEmail;
                        await ChangeEmployee(emp); 
                        GetEmployeeList();
                    }
                    else
                    {
                        fout = 1;
                        FoutMelding = "Gelieve een juist mail adres in te geven.";
                    }    
                }
                else
                {
                    fout = 1;
                    FoutMelding = "Gelieve correcte gegevenss in te geven.";
                }
            }
            //Als er geen foutmelding is 
            if(fout == 0)
            {
                LijstEnable = true;
                WijzigEnable = false;
                NieuwEnable = true;
                OpslaanAnnulerenEnable = false;
                Verwijderenable = false;
                TXTEnable = false;
            }
        }
        //Method Annuleren
        private void MedewerkerAnnuleren()
        {
            EmployeeAdres = "";
            EmployeeEmail = "";
            EmployeeName = "";
            EmployeeTel = "";
            SelectedEmployee = null;
            LijstEnable = true;
            WijzigEnable = false;
            NieuwEnable = true;
            OpslaanAnnulerenEnable = false;
            Verwijderenable = false;
            TXTEnable = false;
        }
        //Verwijderen medewerker Method
        private async void MedewerkerVerwijderen()
        {
            await DeleteEmployee(SelectedEmployee);
            SelectedEmployee = null;
            GetEmployeeList();
        }

        #endregion

        #region Tasks

        //Ophalen Medewerkers
        public async Task<List<Employee>> GetEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/employee");
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Employee> result = JsonConvert.DeserializeObject<List<Employee>>(json);
                    ListEmployees = result;
                    return result;
                }
            }
            return null;
        }
        //Save Nieuwe Medewerker
        public async Task<int> SaveEmployee(Employee newEmployee)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/employee");
                string json = JsonConvert.SerializeObject(newEmployee);
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
        //Verander Medewerker
        public async Task<int> ChangeEmployee(Employee changedEmployee)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/employee");
                string json = JsonConvert.SerializeObject(changedEmployee);
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
        //Verwijder Medewerker TASK
        public async Task<bool> DeleteEmployee(Employee delEmployee)
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                string url = string.Format("{0}{1}", URL, "/employee/" + delEmployee.ID);
                HttpResponseMessage response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



        #endregion
    }
}
