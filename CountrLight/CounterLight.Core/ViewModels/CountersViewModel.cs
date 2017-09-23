using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Countr.Core.Models;
using Countr.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace Countr.Core.ViewModels
{
    public class CountersViewModel : ViewModelBase
    {
        readonly ICountersService service;
        readonly INavigationService navigationService;

        public CountersViewModel(ICountersService service, IMessenger messenger, INavigationService navigationService)
        {
            this.service = service;
            this.navigationService = navigationService;
            messenger.Register<CountersChangedMessage>(this, async m => await LoadCounters());
            Counters = new ObservableCollection<CounterViewModel>();
            ShowAddNewCounterCommand = new RelayCommand(ShowAddNewCounter);
            LoadCounters();
        }

        private ObservableCollection<CounterViewModel> _counters;
        public ObservableCollection<CounterViewModel> Counters
        {
            get { return _counters; }
            set { Set(ref _counters, value); }
        }

        public async Task LoadCounters()
        {
            var newCounters = new ObservableCollection<CounterViewModel>();
            var counters = await service.GetAllCounters();
            foreach (var counter in counters)
            {
                var viewModel = new CounterViewModel(service, navigationService);
                viewModel.Prepare(counter);
                newCounters.Add(viewModel);
            }
            Counters = newCounters;
        }

        public ICommand ShowAddNewCounterCommand { get; }

        void ShowAddNewCounter()
        {
            navigationService.NavigateTo(nameof(CounterViewModel), new Counter());
        }
    }
}