using Countr.Core.Repositories;
using Countr.Core.Services;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace Countr.Core.ViewModels
{
    public static class ViewModelLocator
    {
        static ViewModelLocator()
        {
            SimpleIoc.Default.Register<CountersViewModel>();
            SimpleIoc.Default.Register<CounterViewModel>();

            SimpleIoc.Default.Register<ICountersService, CountersService>();
            SimpleIoc.Default.Register<ICountersRepository, CountersRepository>();
            SimpleIoc.Default.Register<IMessenger, Messenger>();
        }

        public static void RegisterNavigationService(INavigationService navigationService)
        {
            SimpleIoc.Default.Register(() => navigationService);
        }
    }
}
