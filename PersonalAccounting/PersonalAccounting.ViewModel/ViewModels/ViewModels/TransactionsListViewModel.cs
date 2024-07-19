using PersonalAccounting.Model.Context;
using PersonalAccounting.Model.Model;
using PersonalAccounting.ViewModel.Utilities;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using PersonalAccounting.Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static PersonalAccounting.ViewModel.Constants;
using PersonalAccounting.ViewModel.Commands.ICommands;

namespace PersonalAccounting.ViewModel.ViewModels.ViewModels
{
    public class TransactionsListViewModel : BaseViewModel, ITransactionsListViewModel
    {
        private readonly IUnitOfwork _unitOfwork;
        private ObservableCollection<TransactionsModel> _transactionsCollection;
        private string _startDate;
        private string _selectedRow;


        public TransactionsListViewModel(IRefreshTransactionsGridCommand refreshTransactionsGridCommand, IUnitOfwork unitOfwork)
        {
            RefreshTransactionsGrid = refreshTransactionsGridCommand;
            _unitOfwork = unitOfwork;
        }

        public IRefreshTransactionsGridCommand RefreshTransactionsGrid { get; set; }

        public string StartDate
        {
            get => _startDate;
            set => SetField(ref _startDate, value, nameof(StartDate));
        }

        public string SelectedRow
        {
            get => _selectedRow;
            set
            {
                _selectedRow = value;
            }
        }

        public IUnitOfwork UnitOfWork => _unitOfwork;


        public ObservableCollection<TransactionsModel> TransactionsCollection
        {
            get
            {
                if (_transactionsCollection == null)
                {
                    RefreshTrDataGrid();
                }
                return _transactionsCollection;
            }
            set => SetField(ref _transactionsCollection, value, nameof(TransactionsCollection));
        }

        public void RefreshTrDataGrid()
        {
            using (var dbContextTransaction = UnitOfWork.BeginTransaction())
            {
                var data = UnitOfWork.TransactionsRepository.GetTransactionsList();
                SetField(ref _transactionsCollection, data, nameof(TransactionsCollection));
            }

        }
    }
}
