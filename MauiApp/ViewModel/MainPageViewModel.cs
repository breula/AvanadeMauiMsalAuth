using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAuthApp.Constants;
using MauiAuthApp.MsalClient;
using Microsoft.Identity.Client;

namespace MauiAuthApp.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        string accessToken = string.Empty;

        [ObservableProperty]
        bool isLoggedIn = false;

        readonly string[] Scopes = null;

        public MainPageViewModel()
        {
            Scopes = PCAWrapper.Scopes;
        }

        [RelayCommand]
        public async Task Login()
        {
            IsLoggedIn = false;
            
            try
            {
                UpdateAppState(true);

                // Attempt silent login, and obtain access token.
                var result = await PCAWrapper.Instance.AcquireTokenSilentAsync(Scopes);
                IsLoggedIn = true;

                // Set access token.
                AccessToken = result.AccessToken;

                // Display Access Token from AcquireTokenSilentAsync call.
                await App.AlertSevice.ShowAlertAsync("Sucesso!", "Login efetuado com sucesso, já pode consumir a API");
            }
            // A MsalUiRequiredException will be thrown, if this is the first attempt to login, or after logging out.
            catch (MsalUiRequiredException)
            {
                UpdateAppState(true);

                // Perform interactive login, and obtain access token.
                var result = await PCAWrapper.Instance.AcquireTokenInteractiveAsync(Scopes);
                IsLoggedIn = true;

                // Set access token.
                AccessToken = result.AccessToken;

                // Display Access Token from AcquireTokenInteractiveAsync call.
                await App.AlertSevice.ShowAlertAsync("Sucesso!", "Login efetuado com sucesso, já pode consumir a API");
            }
            catch (Exception ex)
            {
                IsLoggedIn = false;
                await App.AlertSevice.ShowAlertAsync("Exceção ao executar AcquireTokenSilentAsync", ex.Message);
            }
            finally
            {
                UpdateAppState();
            }
        }

        [RelayCommand]
        public async Task Logout()
        {
            try
            {
                UpdateAppState(true);
                await PCAWrapper.Instance.SignOutAsync();
                IsLoggedIn = false;
                AccessToken = string.Empty;
                await App.AlertSevice.ShowAlertAsync("Signed Out", "Sign out complete.");
            }
            catch (Exception ex)
            {
                await App.AlertSevice.ShowAlertAsync("Exceção ao executar AcquireTokenSilentAsync", ex.Message);
            }
            finally
            {
                UpdateAppState();
            }
        }

        [RelayCommand]
        public async Task GetWeatherForecast()
        {
            if (AccessToken == string.Empty)
            {
                await App.AlertSevice.ShowAlertAsync("Não logado", "Para consumir API é necessário estar logado");
            }

            try
            {
                UpdateAppState(true);

                // Get the weather forecast data from the Secure Web API.
                var client = new HttpClient();

                // Create the request.
                var message = new HttpRequestMessage(HttpMethod.Get, $"{AppConstants.APIUrl}/weatherforecast");

                // Add the Authorization Bearer header.
                message.Headers.Add("Authorization", $"Bearer {AccessToken}");

                // Send the request.
                var response = await client.SendAsync(message);

                // Get the response.
                var responseString = await response.Content.ReadAsStringAsync();

                // Return the response.
                await App.AlertSevice.ShowAlertAsync("Weather forecast is..", responseString);
            }
            catch (Exception ex)
            {
                await App.AlertSevice.ShowAlertAsync("ÍÍiii... moiô", ex.Message);
            }
            finally 
            { 
                UpdateAppState(); 
            }
        }
    }
}
