using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedbaseLibrary.Services;
using System.Diagnostics;

namespace MedbaseHybrid.ViewModels
{
    public partial class MoreViewModel : ViewModelBase
    {
        [ObservableProperty]
        private int darkStrokeThickness;
        [ObservableProperty]
        private int lightStrokeThickness;
        [ObservableProperty]
        private int systemStrokeThickness;
        [ObservableProperty]
        string appVersion;

        public MoreViewModel()
        {
            AppVersion = VersionTracking.Default.CurrentVersion.ToString();
        }

        [RelayCommand]
        static async Task GoToHelp() => await Browser.OpenAsync(Constants.GoToMedbaseLink("help"));
        [RelayCommand]
        async Task SocialMediaLinks(string link) => await Browser.OpenAsync($"https://{link}");
        [RelayCommand]
        void ChangeTheme(string theme)
        {
            if (theme is null) return;

            try
            {
                switch (theme)
                {
                    case "Unspecified":
                        Application.Current.UserAppTheme = AppTheme.Unspecified;
                        SystemStrokeThickness = 2;
                        DarkStrokeThickness = 0;
                        LightStrokeThickness = 0;
                        break;
                    case "Light":
                        Application.Current.UserAppTheme = AppTheme.Light;
                        SystemStrokeThickness = 0;
                        DarkStrokeThickness = 0;
                        LightStrokeThickness = 2;
                        break;
                    case "Dark":
                        Application.Current.UserAppTheme = AppTheme.Dark;
                        SystemStrokeThickness = 0;
                        LightStrokeThickness = 0;
                        DarkStrokeThickness = 2;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.InnerException.Message);
            }
        }
    }
}