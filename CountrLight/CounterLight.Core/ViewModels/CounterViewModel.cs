using System.Threading.Tasks;
using System.Windows.Input;
using Countr.Core.Models;
using Countr.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace Countr.Core.ViewModels
{
    public class CounterViewModel : ViewModelBase
    {
        Counter counter;
        readonly ICountersService service;
        readonly INavigationService navigationService;

        public CounterViewModel(ICountersService service, INavigationService navigationService)
        {
            this.service = service;
            this.navigationService = navigationService;
            IncrementCommand = new RelayCommand(async () => await IncrementCounter());
            DeleteCommand = new RelayCommand(async () => await DeleteCounter());
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(async () => await Save());
        }

        public ICommand IncrementCommand { get; }

        async Task IncrementCounter()
        {
            await service.IncrementCounter(counter);
            RaisePropertyChanged(() => Count);
        }

        public ICommand DeleteCommand { get; }

        async Task DeleteCounter()
        {
            await service.DeleteCounter(counter);
        }

        public void Prepare(Counter counter)
        {
            this.counter = counter;
        }

        public string Name
        {
            get { return counter.Name; }
            set
            {
                if (Name == value) return;
                counter.Name = value;
                RaisePropertyChanged();
            }
        }

        public int Count => counter.Count;

        public ICommand CancelCommand { get; }
        public ICommand SaveCommand { get; }

        void Cancel()
        {
            navigationService.GoBack();                            
        }

        async Task Save()
        {
            await service.AddNewCounter(counter.Name);                      
            navigationService.GoBack();
        }
    }
}