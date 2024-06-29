using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Services.NavigationServices
{

    public class ReportsNavigationService : IReportsNavigationService
    {
        private readonly INavigationStore _navigationStore;
        private readonly IReportsViewModel _reportsViewModel;

        public ReportsNavigationService(INavigationStore navigationStore, IReportsViewModel reportsViewModel)
        {
            _navigationStore = navigationStore;
            _reportsViewModel = reportsViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _reportsViewModel;
        }
    }
}
