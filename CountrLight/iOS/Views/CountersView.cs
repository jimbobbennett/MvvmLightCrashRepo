using System;
using Countr.Core.ViewModels;
using UIKit;
using GalaSoft.MvvmLight.Helpers;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace Countr.iOS.Views
{
    public partial class CountersView : ObservableTableViewController<CounterViewModel>
    {
        public CountersView(IntPtr handle) 
        {
            Handle = handle;
        }

        CountersViewModel viewModel;
        readonly List<Binding> bindings = new List<Binding>();
        UIBarButtonItem addCounterButton;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            try
            {
                viewModel = SimpleIoc.Default.GetInstance<CountersViewModel>();

                var source = new CountersTableViewSource();
                TableView.Source = source;

                addCounterButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);
                addCounterButton.AccessibilityIdentifier = "add_counter_button";
                NavigationItem.SetRightBarButtonItem(addCounterButton, false);

                bindings.Add(this.SetBinding(() => viewModel.Counters, () => DataSource));

                // Using this - new view controller is shown
                //addCounterButton.Clicked += (sender, e) =>
                //{
                //    var storyboard = UIStoryboard.FromName("Main", null);
                //    var vc = storyboard.InstantiateViewController("CounterView");
                //    ShowViewController(vc, this);
                //};

                // Using this - app crashes
                addCounterButton.SetCommand(nameof(UIBarButtonItem.Clicked), viewModel.ShowAddNewCounterCommand);
            }
            catch { }
        }
    }
}

