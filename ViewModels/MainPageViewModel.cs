using Sharpcaster.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SharpCaster.Demo
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private IEnumerable<ChromecastReceiver> _data;
        public IEnumerable<ChromecastReceiver> Data
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
            Data = await locator.FindReceiversAsync();
        }
    }
}
