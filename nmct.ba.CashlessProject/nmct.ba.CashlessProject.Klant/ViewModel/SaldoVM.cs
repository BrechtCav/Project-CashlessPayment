
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

namespace nmct.ba.CashlessProject.Klant.ViewModel
{
    class SaldoVM : ObservableObject, IPage
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        private const string URL = "http://localhost:7695/api";
        public string Name
        {
            get { return "Saldo"; }
        }
        public SaldoVM()
        {
            HuidigSaldo = SelectedCustomer.Balance;
            TotaalTonen();
        }
        private double huidigsaldo;
        public double HuidigSaldo
        {
            get { return huidigsaldo; }
            set { huidigsaldo = value; OnPropertyChanged("HuidigSaldo"); }
        }
        private string melding;
        public string Melding
        {
            get { return melding; }
            set { melding = value; OnPropertyChanged("Melding"); }
        }
        private double extrasaldo;
        public double ExtraSaldo
        {
            get { return extrasaldo; }
            set { extrasaldo = value; OnPropertyChanged("ExtraSaldo"); }
        }
        private double totaalsaldo;
        public double TotaalSaldo
        {
            get { return totaalsaldo; }
            set { totaalsaldo = value; OnPropertyChanged("TotaalSaldo"); }
        }
        public ICommand Annuleren
        {
            get { return new RelayCommand(SaldoAnnuleren); }
        }
        private void SaldoAnnuleren()
        {
            appvm.ChangePage(new AccountVM());
        }
        //Aantal van een product
        private double amount = 0;
        public double Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged("Amount"); }
        }
        //Icommand voor hoger aantal
        public ICommand AmountUp
        {
            get { return new RelayCommand(UpAmount); }
        }
        //ICommand voor lager aantal
        public ICommand AmountDown
        {
            get { return new RelayCommand(DownAmount); }
        }
        public ICommand Opladen
        {
            get { return new RelayCommand(BedragOpladen); }
        }
        //Void voor aantal omhoog
        public void UpAmount()
        {
            if(TotaalSaldo <100)
            {
                Amount++;
                TotaalTonen();
            }
            else
            {
                Melding = "Er kan maar een bedrag van 100 € op de kaart staan.";
            }
        }

        //Void voor aantal omlaag
        public void DownAmount()
        {
            if (Amount > 1)
            {
                Amount--;
                TotaalTonen();
            }
        }
        private void TotaalTonen()
        {
            TotaalSaldo = HuidigSaldo + Amount;
            if(TotaalSaldo > 100)
            {
                TotaalSaldo = 100;
                Amount = TotaalSaldo - HuidigSaldo;
                Melding = "Er kan maar een bedrag van 100 € op de kaart staan.";
            }
        }
        private async void BedragOpladen()
        {
            Transfer changedCustomer = new Transfer();
            changedCustomer.Amount = Amount;
            changedCustomer.Cust = SelectedCustomer;
            changedCustomer.Teken = 1;
            await TransferMoney(changedCustomer);
            SelectedCustomer.Balance = HuidigSaldo + Amount;
            AccountVM.SelectedCustomer.Balance = HuidigSaldo + Amount;
            appvm.ChangePage(new AccountVM());
        }
        public async Task<int> TransferMoney(Transfer changedCustomer)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = string.Format("{0}{1}", URL, "/TransferKL");
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
        public static Customer SelectedCustomer { get; set; }
    }
}
