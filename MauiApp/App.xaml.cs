using MauiAuthApp.Services.Interfaces;

namespace MauiAuthApp
{
    public partial class App : Application
    {
        public static IServiceProvider Services;
        public static IAlertService AlertSevice;

        public App(IServiceProvider provider)
        {
            InitializeComponent();

            Services = provider;
            AlertSevice = Services.GetService<IAlertService>();

            MainPage = new AppShell();
        }
    }
}