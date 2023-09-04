using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedbaseHybrid.Controls;
using MedbaseLibrary.Models;
using MedbaseHybrid.Pages;
using MedbaseHybrid.Services;
using MedbaseLibrary.Services;
using MvvmHelpers;

namespace MedbaseHybrid.ViewModels
{
    [QueryProperty(nameof(TopicSelected), "topicSelected")]
    [QueryProperty(nameof(Source), "sourceFromTopic")]
    public partial class QuestionsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Question> Questions { get; set; } = new();

        [ObservableProperty]
        private Topic topicSelected;

        [ObservableProperty]
        private bool answersVisible = false;

        [ObservableProperty]
        private string source;
        [ObservableProperty]
        private bool isBusy;

        public QuestionsViewModel(IApiRepository _apiService, IDatabaseRepository _repo)
        {
            apiService = _apiService;
            databaseService = _repo;
        }
        [RelayCommand]
        public async Task GetQuestions()
        {
            IsBusy = true;
            if (TopicSelected == null) return;
            Questions.Clear();
            QuestionPaged questionPaged = new();

            try
            {
                if (Source.Equals("online"))
                {
                    //questionPaged = await apiService.GetPagedQuestions(TopicSelected.TopicRef, 1, 10f);
                    //Questions.AddRange(questionPaged.Questions);

                    Questions.AddRange(await apiService.GetQuestionsSimple(TopicSelected.TopicRef));
                }
                else if (Source.Equals("offline"))
                {
                    //questionPaged = await databaseService.GetQuestionsPaged(TopicSelected.TopicRef, 1, 10f);
                    //Questions.AddRange(questionPaged.Questions);

                    Questions.AddRange(databaseService.GetQuestionsAsync(TopicSelected.TopicRef));
                }
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Your internet connection seems to be a bit shaky. Try again", "I understand");
            }
            IsBusy = false;
        }

        [RelayCommand]
        async Task ShowAnswers(Question question)
        {
            //if(question == null) return;
            var page = new AnswersBottomSheet(question);
            page.HasHandle = true;
            page.HandleColor = Color.Parse("#3b3b3b");
            page.HasBackdrop = true;

            await page.ShowAsync(Shell.Current.Window, true);

            //Shell.Current.ShowPopup(new AnswersPopup(question));   
        }
        [RelayCommand]
        async Task GoToExportImage(Question question)
        {
            if (question is null) return;
            await Shell.Current.GoToAsync(nameof(ExportImagePage), true, new Dictionary<string, object>
            {
                {"topicToExport", TopicSelected },
                {"questionToExport", question}
            });
        }
    }
}
