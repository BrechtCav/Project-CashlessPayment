using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nmct.ba.CashlessProject.Management.ViewModel
{
    class ApplicationVM : ObservableObject
    {
        ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
        public ApplicationVM()
        {
            StartPages.Add(new LoginVM());
            Pages.Add(new PageOneVM());
            // Add other pages

            CurrentPage = StartPages[0];
        }

        private object currentPage;
        public object CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
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
        private List<IPage> startpages;
        public List<IPage> StartPages
        {
            get
            {
                if (startpages == null)
                    startpages = new List<IPage>();
                return startpages;
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
