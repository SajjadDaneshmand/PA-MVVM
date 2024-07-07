using PersonalAccounting.ViewModel.Commands.ICommands;
using PersonalAccounting.ViewModel.Services;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        public HomeViewModel()
        {
        }

        public string TodayDate => DateTime.Today.ToString("yyyy/MM/dd");

    }
}
