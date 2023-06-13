using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiAuthApp.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;

        [ObservableProperty]
        bool isRefreshing;

        public BaseViewModel()
        {
            UpdateAppState();
        }

        public void UpdateAppState(bool busiest = false, bool refreshing = false)
        {
            IsRefreshing = refreshing;
            IsBusy = busiest;
        }
    }
}
