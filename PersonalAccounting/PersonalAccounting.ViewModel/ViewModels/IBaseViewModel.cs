using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels
{
    internal interface IBaseViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}
