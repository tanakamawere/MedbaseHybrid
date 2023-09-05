using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedbaseHybrid.Controls;
using MedbaseHybrid.Services;
using MedbaseLibrary.Models;
using MedbaseLibrary.Services;
using Mopups.Interfaces;
using The49.Maui.BottomSheet;

namespace MedbaseHybrid.ViewModels
{
    public partial class AnswersSheetViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Question question;

        BottomSheet bottomSheet;

        public AnswersSheetViewModel(IApiRepository repo, Question _question, IPopupNavigation _popupNavigation, BottomSheet _bottomSheet)
        {
            apiService = repo;
            popupService = _popupNavigation;
            question = _question;
            bottomSheet = _bottomSheet;
        }

        [RelayCommand]
        async Task OpenCorrectionsPopup()
        {
            if (Helpers.InternetAvailable().Equals(true))
            {
                await bottomSheet.DismissAsync();
                await popupService.PushAsync(new CorrectionsPopup(apiService, question, popupService));
            }
            else
            {
                await Toast.Make("You need internet to make corrections. Connect to a network", CommunityToolkit.Maui.Core.ToastDuration.Long, 12).Show();
            }
        }
    }
}
