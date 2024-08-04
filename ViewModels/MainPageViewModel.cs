using Sharpcaster.Models;
using SharpCaster.Demo.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SharpCaster.Demo
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand ConnectCommand { get; }
        private ChromecastService _chromecastService;
        public MainPageViewModel(ChromecastService chromecastService)
        {
            _chromecastService = chromecastService;
            ConnectCommand = new Command<ChromecastReceiver>(ConnectToChromecast);
        }
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

        private async void ConnectToChromecast(ChromecastReceiver receiver)
        {
            Data.First(x => x.Name == receiver.Name).Status = "Connected";
            OnPropertyChanged(nameof(Data));
            _chromecastService.Receiver = receiver;
            var i = 0;
            await _chromecastService.Connect();
            await _chromecastService.LaunchApplication();
        }
    }
}
