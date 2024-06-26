using Autofac;
using Autofac.Core;

using PersonalAccounting.ViewModel.ViewModels.IViewModels;
using PersonalAccounting.ViewModel.ViewModels.ViewModels;
using PersonalAccounting.ViewModel;
using PersonalAccounting.ViewModel.ViewModels;

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

            // Register Commands
            
            // Register Services

            // Register Stores


            return builder.Build();
        }
    }
}
