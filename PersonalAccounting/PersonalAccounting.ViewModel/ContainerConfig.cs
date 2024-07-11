using Autofac;
using Autofac.Core;

using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using PersonalAccounting.ViewModel.ViewModels.ViewModels;
using PersonalAccounting.ViewModel;
using PersonalAccounting.ViewModel.ViewModels;
using PersonalAccounting.ViewModel.Services;
using PersonalAccounting.ViewModel.Services.NavigationServices;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using static PersonalAccounting.ViewModel.Constants;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel.Commands.Commands;
using PersonalAccounting.ViewModel.Commands.ICommands;
using System.Data.SqlClient;
using PersonalAccounting.Model.Repositories;
using PersonalAccounting.Model.Services;
using PersonalAccounting.Model.Context;
using PersonalAccounting.ViewModel.Utilities;

namespace PersonalAccounting.ViewModel
{
    public class ContainerConfig
    {
        public static Autofac.IContainer Configure(object parametrs)
        {
            var builder = new ContainerBuilder();

            // Register ViewModels and their interfaces
            builder.RegisterType<BaseViewModel>().As<IBaseViewModel>();
            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>().SingleInstance();
            builder.RegisterType<HomeViewModel>().As<IHomeViewModel>().SingleInstance();
            builder.RegisterType<PersonsViewModel>().As<IPersonsViewModel>().SingleInstance();
            builder.RegisterType<TransactionsViewModel>().As<ITransactionsViewModel>().SingleInstance();
            builder.RegisterType<ReportsViewModel>().As<IReportsViewModel>().SingleInstance();
            builder.RegisterType<SettingsViewModel>().As<ISettingsViewModel>().SingleInstance();
            builder.RegisterType<NewPersonViewModel>().As<INewPersonViewModel>().SingleInstance();
            builder.RegisterType<PersonsListViewModel>().As<IPersonsListViewModel>().OnActivated(
                e =>
                {
                    using (var db = new UnitOfWork())
                    {
                        var persons = db.CustomersRepository.GetAllCustomers();
                        e.Instance.PersonsCollection = persons;
                    }

                    var deleteCustomerCommand = e.Context.Resolve<IDeleteCustomerCommand>();

                    e.Instance.DeleteRow = deleteCustomerCommand;

                    if (deleteCustomerCommand is DeleteCustomerCommand command)
                    {
                        command.PersonsListViewModelInstance = e.Instance;
                        e.Instance.PropertyChanged += command.OnViewModelPropertyChanged;
                    }

                    


                }
                ).SingleInstance();
            builder.RegisterType<NewTransactionViewModel>().As<INewTransactionViewModel>().SingleInstance();
            builder.RegisterType<TransactionsListViewModel>().As<ITransactionsListViewModel>().SingleInstance();

            // Register Commands
            builder.RegisterType<NavigateToHomeCommand>().As<INavigateToHomeCommand>().SingleInstance();
            builder.RegisterType<NavigateToPersonsCommand>().As<INavigateToPersonsCommand>().SingleInstance();
            builder.RegisterType<NavigateToTransactionsCommand>().As<INavigateToTransactionsCommand>().SingleInstance();
            builder.RegisterType<NavigateToReportsCommand>().As<INavigateToReportsCommnad>().SingleInstance();
            builder.RegisterType<NavigateToSettingsCommand>().As<INavigateToSettingsCommand>().SingleInstance();
            builder.RegisterType<NavigateToNewPersonCommand>().As<INavigateToNewPersonCommand>().SingleInstance();
            builder.RegisterType<NavigateToPersonsListCommand>().As<INavigateToPersonsListCommand>().SingleInstance();
            builder.RegisterType<NavigateToNewTransactionCommand>().As<INavigateToNewTransactionCommand>().SingleInstance();
            builder.RegisterType<NavigateToTransactionsListCommand>().As<INavigateToTransactionsListCommand>().SingleInstance();
            builder.RegisterType<DeleteCustomerCommand>().As<IDeleteCustomerCommand>();
            builder.RegisterType<CreateCustomerAndNavigateToPersonsListCommand>().As<ICreateCustomerAndNavigateToPersonsListCommand>().OnActivated(
                e =>
                {
                    var currentViewModel = e.Context.Resolve<INewPersonViewModel>();
                    var personsListNavigationService = e.Context.Resolve<IPersonsListNavigationService>();
                    var newTransactionViewModel = e.Context.Resolve<INewTransactionViewModel>();
                    e.Instance.NewPersonViewModelInstance = currentViewModel;
                    e.Instance.PersonsListNavigationService = personsListNavigationService;
                    e.Instance.NewTransactionViewModelInstance = newTransactionViewModel;

                    currentViewModel.PropertyChanged += e.Instance.OnViewModelPropertyChanged;

                });
            builder.RegisterType<CreateCustomerCommand>().As<ICreateCustomerCommand>().OnActivated(
                e =>
                {
                    // We can perform any logic here.
                    var currentViewModel = e.Context.Resolve<INewPersonViewModel>();
                    var personsListViewModel = e.Context.Resolve<IPersonsListViewModel>();
                    var newTransactionViewModel = e.Context.Resolve<INewTransactionViewModel>();
                    e.Instance.NewPersonViewModelInstance = currentViewModel;
                    e.Instance.PersonsListViewModelInstance = personsListViewModel;
                    e.Instance.NewTransactionViewModelInstance = newTransactionViewModel;

                    currentViewModel.PropertyChanged += e.Instance.OnViewModelPropertyChanged;
                }
                );
            builder.RegisterType<CreateTransactionCommand>().As<ICreateTransactionCommand>().OnActivated(
                e =>
                {
                    var currentViewModel = e.Context.Resolve<INewTransactionViewModel>();
                    e.Instance.NewTransactionViewModel = currentViewModel;

                    currentViewModel.PropertyChanged += e.Instance.OnViewModelPropertyChanged;
                });
            builder.RegisterType<RefreshPersonsGridCommand>().As<IRefreshPersonsGridCommand>().OnActivated(
                e =>
                {
                    var personsListViewModel = e.Context.Resolve<IPersonsListViewModel>();
                    e.Instance.PersonsListViewModel = personsListViewModel;
                }
                );
            builder.RegisterType<RefreshTransactionsGridCommand>().As<IRefreshTransactionsGridCommand>().OnActivated(

                e =>
                {
                    var transactionsListViewModel = e.Context.Resolve<ITransactionsListViewModel>();
                    e.Instance.TransactionsListViewModel = transactionsListViewModel;
                });

            // Register Navigation Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<HomeNavigationService>().As<IHomeNavigationService>().SingleInstance();
            builder.RegisterType<PersonsNavigationService>().As<IPersonsNavigationService>().SingleInstance();
            builder.RegisterType<TransactionsNavigationService>().As<ITransactionsNavigationService>().SingleInstance();
            builder.RegisterType<ReportsNavigationService>().As<IReportsNavigationService>().SingleInstance();
            builder.RegisterType<SettingsNavigationService>().As<ISettingsNavigationService>().SingleInstance();
            builder.RegisterType<NewPersonNavigationService>().As<INewPersonNavigationService>().SingleInstance();
            builder.RegisterType<PersonsListNavigationService>().As<IPersonsListNavigationService>().SingleInstance();
            builder.RegisterType<TransactionsListNavigationService>().As<ITransactionsListNavigationService>().SingleInstance();
            builder.RegisterType<NewTransactionNavigationService>().As<INewTransactionNavigationService>().SingleInstance();

            // Register Stores
            builder.RegisterType<NavigationStore>().As<INavigationStore>().SingleInstance();
            builder.RegisterType<PersonsTabNavigationStore>().As<IPersonsTabNavigationStore>().SingleInstance();
            builder.RegisterType<TransactionsTabNavigationStore>().As<ITransactionsTabNavigationStore>().SingleInstance();

            // Register Utilities
            builder.RegisterType<AccountingRegistry>().As<IAccountingRegistry>().SingleInstance();


            // Register Model Repositories
            builder.RegisterType<CustomersRepository>().As<ICustomersRepository>().SingleInstance();

            return builder.Build();
        }
    }
}
