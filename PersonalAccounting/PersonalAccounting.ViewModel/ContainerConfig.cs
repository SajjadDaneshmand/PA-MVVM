using Autofac;
using Autofac.Core;

using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using PersonalAccounting.ViewModel.ViewModels.ViewModels;
using PersonalAccounting.ViewModel;
using PersonalAccounting.ViewModel.ViewModels;
using PersonalAccounting.ViewModel.Services;
using PersonalAccounting.ViewModel.Services.NavigationServices;
using PersonalAccounting.ViewModel.Services.NavigationInterfaces;
using PersonalAccounting.ViewModel.Stores;
using PersonalAccounting.ViewModel.Commands.Commands;
using PersonalAccounting.ViewModel.Commands.ICommands;
using System.Data.SqlClient;

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

            // Register Commands
            builder.RegisterType<NavigateToHomeCommand>().As<INavigateToHomeCommand>().SingleInstance();
            builder.RegisterType<NavigateToPersonsCommand>().As<INavigateToPersonsCommand>().SingleInstance();
            builder.RegisterType<NavigateToTransactionsCommand>().As<INavigateToTransactionsCommand>().SingleInstance();
            builder.RegisterType<NavigateToReportsCommand>().As<INavigateToReportsCommnad>().SingleInstance();
            builder.RegisterType<NavigateToSettingsCommand>().As<INavigateToSettingsCommand>().SingleInstance();
            builder.RegisterType<TestCommand>().As<ITestCommand>().SingleInstance();

            // Register Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<HomeNavigationService>().As<IHomeNavigationService>().SingleInstance();
            builder.RegisterType<PersonsNavigationService>().As<IPersonsNavigationService>().SingleInstance();
            builder.RegisterType<TransactionsNavigationService>().As<ITransactionsNavigationService>().SingleInstance();
            builder.RegisterType<ReportsNavigationService>().As<IReportsNavigationService>().SingleInstance();
            builder.RegisterType<SettingsNavigationService>().As<ISettingsNavigationService>().SingleInstance();

            // Register Stores
            builder.RegisterType<NavigationStore>().As<INavigationStore>().SingleInstance();

            return builder.Build();
        }
    }
}
