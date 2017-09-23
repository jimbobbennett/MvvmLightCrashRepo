using Countr.Core.ViewModels;
using Foundation;
using GalaSoft.MvvmLight.Views;
using UIKit;

namespace CountrLight.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var navigationService = new NavigationService();
            navigationService.Initialize((UINavigationController)Window.RootViewController);
            navigationService.Configure(nameof(CountersViewModel), "CountersView");
            navigationService.Configure(nameof(CounterViewModel), "CounterView");
            ViewModelLocator.RegisterNavigationService(navigationService);

            return true;
        }
    }
}

