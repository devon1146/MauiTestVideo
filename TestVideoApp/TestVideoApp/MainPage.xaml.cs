namespace TestVideoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MainPageViewModel vm = new() { RefreshTask = RefreshWarningLabel };

            BindingContext = new MainPageViewModel();
        }
        private void RefreshWarningLabel(bool visibility)
        {
            lblWarning.IsVisible = visibility;
        }
    }

}
