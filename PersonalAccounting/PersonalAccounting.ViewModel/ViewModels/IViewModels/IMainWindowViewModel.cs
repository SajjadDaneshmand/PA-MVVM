using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.IViewModels
{
    public interface IMainWindowViewModel
    {
        IBaseViewModel CurrentViewModel { get; }
    }
}
