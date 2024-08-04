using Sharpcaster.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SharpCaster.Demo
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ChromecastReceiver> _data;
        public ObservableCollection<ChromecastReceiver> Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task LoadDataAsync()
        {
            // Simulate an async data load
            Sharpcaster.MdnsChromecastLocator locator = new();
            Data = new ObservableCollection<ChromecastReceiver>(await locator.FindReceiversAsync());
            var i = 0;
        }
    }
}
