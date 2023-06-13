using CommunityToolkit.Maui;
using MauiAuthApp.Services.Implementations;
using MauiAuthApp.Services.Interfaces;
using MauiAuthApp.ViewModel;

namespace MauiAuthApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            #region Services
            builder.Services.AddSingleton<IAlertService, AlertService>();

            #endregion

            #region UI Registration
            builder.Services.AddScoped<MainPage>();

            #endregion

            #region ViewModel registration
            builder.Services.AddSingleton<MainPageViewModel>();

            #endregion

            return builder.Build();
        }
    }
}