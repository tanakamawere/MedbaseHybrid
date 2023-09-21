namespace MedbaseHybrid.ViewModels
{
    public partial class ViewModelBase : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public IApiRepository apiService;
        public IDatabaseRepository databaseService;
        public IPopupNavigation popupService;

        public LoadingPopup loadingPopup;
        [ObservableProperty]
        bool isBusy;

        public ViewModelBase()
        {
        }
    }
}
