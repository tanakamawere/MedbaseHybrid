using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedbaseHybrid.Services;
using MedbaseLibrary.Models;
using MedbaseLibrary.Services;
using Mopups.Interfaces;

namespace MedbaseHybrid.ViewModels
{
    public partial class CorrectionsPopupViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Question question;
        [ObservableProperty]
        private string questionChild;
        [ObservableProperty]
        private bool questionAnswer;
        [ObservableProperty]
        private string questionExplanation = "";
        
        public CorrectionsPopupViewModel(IApiRepository repo, Question _question, IPopupNavigation _popupNavigation)
        {
            apiService = repo;
            question = _question;
            popupService = _popupNavigation;
            loadingPopup = new Controls.LoadingPopup();

            //randomly set the answer to something
            QuestionAnswer = question.AnswerB;
        }

        [RelayCommand]
        async Task PostCorrection()
        {
            await popupService.PushAsync(loadingPopup);
            try
            {
                if (!string.IsNullOrEmpty(QuestionChild) || QuestionAnswer.Equals(null))
                {
                    Corrections corrections = new Corrections(0, Question.Id, QuestionChild, QuestionAnswer, QuestionExplanation);
                    var response = await apiService.PostCorrection(corrections);
                    if (response.Equals(true))
                    {
                        await Toast.Make("Your correction was sent successfully. The Medbase team will review it soon.", CommunityToolkit.Maui.Core.ToastDuration.Long, 12).Show();
                    }
                    else
                    {
                        await Toast.Make("There was a problem posting your correction. Please try again.", CommunityToolkit.Maui.Core.ToastDuration.Long, 12).Show();
                    }
                }
                else
                {
                    await Toast.Make("You didn't write an answer or select a question", CommunityToolkit.Maui.Core.ToastDuration.Long, 12).Show();
                }
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Technical glitch here. Please try again", "I understand");
            }
            finally
            {
                await popupService.PopAllAsync();
            }
        }
    }
}
