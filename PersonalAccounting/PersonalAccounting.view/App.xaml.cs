using Autofac; 
using PersonalAccounting.ViewModel.ViewModels;
using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using static PersonalAccounting.ViewModel.Constants;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel;
using PersonalAccounting.view.Views;
using System.Windows;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using PersonalAccounting.ViewModel.Utilities;
using System;
using System.Runtime.InteropServices.ComTypes;


namespace PersonalAccounting.view
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IContainer _container;

        public App()
        {
            _container = ContainerConfig.Configure(null);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Resolve necessary view models from the container
            var mainWindowViewModel = _container.Resolve<IMainWindowViewModel>();

            MainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel,
            };

            base.OnStartup(e);
            MainWindow.Show();

            var homeNavigationService = _container.Resolve<IHomeNavigationService>();
            homeNavigationService.Navigate();

            var personListNavigationService = _container.Resolve<IPersonsListNavigationService>();
            personListNavigationService.Navigate();

            var transactionsListNavigationService = _container.Resolve<ITransactionsListNavigationService>();
            transactionsListNavigationService.Navigate();

            var accountingRegistry = _container.Resolve<IAccountingRegistry>();

            if (!accountingRegistry.IsRegistryExist)
            {
                var today = DateTime.Today.ToString("yyyy/MM/dd");
                accountingRegistry.Write(START_DATE_REGISTRY_KEY, today);
            }

            var transactionListViewModel = _container.Resolve<ITransactionsListViewModel>();

            transactionListViewModel.StartDate = accountingRegistry.Get(START_DATE_REGISTRY_KEY);



        }
    }
}
