﻿using PersonalAccounting.Model.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.ViewModels.IViewModels
{
    public interface IPersonsListViewModel: IBaseViewModel
    {
        Customers SelectedRow { get; set; }
        void UpdatePersonList();
        ObservableCollection<Customers> PersonsCollection {  get; set; }
        void RefreshGrid();
    }
}
