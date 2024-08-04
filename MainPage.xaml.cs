namespace SharpCaster.Demo
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
            LoadData();
        }

        private async void LoadData()
        {
            await viewModel.LoadDataAsync();
        }
    }
}
