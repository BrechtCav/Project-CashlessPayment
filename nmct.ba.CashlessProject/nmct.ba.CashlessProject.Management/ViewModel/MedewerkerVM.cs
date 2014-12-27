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
        int ToggleWijzigNieuw;
        //
        private Employee selectedemployee = null;
        public Employee SelectedEmployee
        {
            get { return selectedemployee; }
            set { selectedemployee = value; OnPropertyChanged("SelectedEmployee"); }
        }

        private List<Employee> listemployees;
        public List<Employee> ListEmployees
        {
            get { return listemployees; }
            set { listemployees = value; OnPropertyChanged("ListEmployees"); }
        }

        private string employeename;
        public string EmployeeName
        {
            get { return employeename; }
            set { employeename = value; OnPropertyChanged("EmployeeName"); }
        }

        
        private string employeeadres;
        public string EmployeeAdres
        {
            get { return employeeadres; }
            set { employeeadres = value; OnPropertyChanged("EmployeeAdres"); }
        }


        private string employeeemail;
        public string EmployeeEmail
        {
            get { return employeeemail; }
            set { employeeemail = value; OnPropertyChanged("EmployeeEmail"); }
        }


        private string employeetel;
        public string EmployeeTel
        {
            get { return employeetel; }
            set { employeetel = value; OnPropertyChanged("EmployeeTel"); }
        }

        private string foutmelding;
        public string FoutMelding
        {
            get { return foutmelding; }
            set { foutmelding = value; OnPropertyChanged("FoutMelding"); }
        }






        #endregion
        #region ICommands


        public ICommand btnNieuw
        {
            get { return new RelayCommand(NieuwProduct); }
        }


        public ICommand btnWijzig
        {
            get { return new RelayCommand(WijzigProduct); }
        }

        public ICommand btnOpslaan
        {
            get { return new RelayCommand(ProductOpslaan); }
        }

        public ICommand btnAnnuleren
        {
            get { return new RelayCommand(ProductAnnuleren); }
        }

        public ICommand btnVerwijder
        {
            get { return new RelayCommand(ProductVerwijderen); }
        }


        //ICommand voor lijst tonen
        public ICommand ToonGekozenMedewerker
        {
            get { return new RelayCommand(ToonMedewerker); }
        }


        #endregion
        #region Voids
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
        private async void GetEmployeeList()
        {
            await GetEmployees();
        }

        private void NieuwProduct()
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
        private void WijzigProduct()
        {
            ToggleWijzigNieuw = 1;
            LijstEnable = false;
            WijzigEnable = false;
            NieuwEnable = false;
            OpslaanAnnulerenEnable = true;
            Verwijderenable = false;
            TXTEnable = true;
        }

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
        private async void ProductOpslaan()
        {
            int fout = 0;
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
        private void ProductAnnuleren()
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
        private async void ProductVerwijderen()
        {
            await DeleteEmployee(SelectedEmployee);
            SelectedEmployee = null;
            GetEmployeeList();
        }

        #endregion
        #region Tasks


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
