using SharpCaster.Demo.Services;

namespace SharpCaster.Demo
{
    public partial class MainPage : ContentPage
    {
        private ChromecastService _chromecastService;
        private MainPageViewModel _mainPageViewModel;

        public MainPage(ChromecastService chromecastService, MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            _mainPageViewModel = mainPageViewModel;
            _chromecastService = chromecastService;
            BindingContext = mainPageViewModel;
            LoadData();
        }

        private async void LoadData()
        {
            await _mainPageViewModel.LoadDataAsync();
        }

    }
}
