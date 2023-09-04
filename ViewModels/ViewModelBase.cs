using CommunityToolkit.Mvvm.ComponentModel;
using MedbaseHybrid.Controls;
using MedbaseHybrid.Services;
using MedbaseLibrary.Services;
using Mopups.Interfaces;

namespace MedbaseHybrid.ViewModels
{
    public partial class ViewModelBase : ObservableObject
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
