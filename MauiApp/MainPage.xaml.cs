using MauiAuthApp.ViewModel;

namespace MauiAuthApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}