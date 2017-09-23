using Countr.Core.ViewModels;
using GalaSoft.MvvmLight.Helpers;

namespace Countr.iOS.Views
{
    public class CountersTableViewSource : ObservableTableViewSource<CounterViewModel>
    {
        public CountersTableViewSource()
        {
            CreateCellDelegate = s => new CounterTableViewCell();
            BindCellDelegate = (c, v, p) => ((CounterTableViewCell)c).Bind(v);
            ReuseId = "CounterTableViewCell";
        }
    }
}