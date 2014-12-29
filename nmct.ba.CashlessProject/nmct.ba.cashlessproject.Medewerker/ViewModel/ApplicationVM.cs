using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Thinktecture.IdentityModel.Client;

namespace nmct.ba.cashlessproject.Medewerker.ViewModel
{
    class ApplicationVM : ObservableObject
    {
        public static TokenResponse token = null;
        public ApplicationVM()
        {
            
            Pages.Add(new BestellingVM());
            Startpage.Add(new PageOneVM());
            // Add other pages

            CurrentPage = Startpage[0];
        }


        private bool menuvisibility = false;
        public bool MenuVisibility
        {
            get { return menuvisibility; }
            set { menuvisibility = value; OnPropertyChanged("MenuVisibility"); }
        }
        private object currentPage;
        public object CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
        }

        private List<IPage> startpage;
        public List<IPage> Startpage
        {
            get
            {
                if (startpage == null)
                    startpage = new List<IPage>();
                return startpage;
            }
        }

        private List<IPage> pages;
        public List<IPage> Pages
        {
            get
            {
                if (pages == null)
                    pages = new List<IPage>();
                return pages;
            }
        }

        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }

        public void ChangePage(IPage page)
        {
            CurrentPage = page;
        }
    }
}
