﻿using PersonalAccounting.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccounting.ViewModel.Stores
{
    public class PersonsTabNavigationStore: IPersonsTabNavigationStore
    {
        private IBaseViewModel _currentViewModel;

        public event Action CurrentViewModelChanged;

        public IBaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}