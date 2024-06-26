using PersonalAccounting.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Stores
{
    public interface INavigationStore
    {
        IBaseViewModel CurrentViewModel { get; set;  }

        event Action CurrentViewModelChanged;
    }
}
