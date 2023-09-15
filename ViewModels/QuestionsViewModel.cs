using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedbaseHybrid.Controls;
using MedbaseLibrary.Models;
using MedbaseHybrid.Pages;
using MedbaseHybrid.Services;
using MedbaseLibrary.Services;
using MvvmHelpers;
using Mopups.Interfaces;
using CommunityToolkit.Maui.Alerts;
using Plugin.MauiMTAdmob;

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

        [ObservableProperty]
        private QuestionPaged questionPaged = new();
        [ObservableProperty]
        private string searchTerm;

        [ObservableProperty]
        private bool openSearch = false;

        [ObservableProperty]
        private string currentPageNumber;

        public QuestionsViewModel(IApiRepository _apiService, IDatabaseRepository _repo, IPopupNavigation popup)
        {
            apiService = _apiService;
            popupService = popup;
            databaseService = _repo;
        }

        [RelayCommand]
        public async Task GetQuestions()
        {
            IsBusy = true;

            if (TopicSelected == null) return;
            Questions.Clear();

            try
            {
                await GetQuestionsFromApi(1);
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
            if(question == null) return;

            var page = new AnswersBottomSheet(apiService ,question, popupService);

            await page.ShowAsync(Shell.Current.Window, true); 
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
        //Go to search questions page
        [RelayCommand]
        async Task OpenSearchBar()
        {
            Vibration.Default.Vibrate(300);


            OpenSearch = !OpenSearch;
        }
        //Method to search questions on the API
        [RelayCommand]
        async Task Search()
        {
            //Open dialog for user to write search term
            SearchTerm = await Shell.Current.DisplayPromptAsync("Search", "Enter search term", "Search", "Cancel", "Search term", 12, Keyboard.Default, null);

            try
            {
                IsBusy = true;
                //check if search term is not empty
                if (SearchTerm is not null)
                {
                    QuestionPaged = null;
                    //Check if source is online or offline
                    if (Source.Equals("online"))
                    {
                        //Get questions from API
                        QuestionPaged = await apiService.GetSearchPagedQuestions(TopicSelected.TopicRef, 1, 10f, SearchTerm);
                        Questions.AddRange(QuestionPaged.Questions);
                    }
                    else if (Source.Equals("offline"))
                    {
                        //Get questions from database
                        QuestionPaged = await databaseService.GetSearchQuestionsPaged(TopicSelected.TopicRef, 1, 10f, SearchTerm);
                        Questions.AddRange(QuestionPaged.Questions);
                    }
                }
                else
                {
                    //Display toast saying that search term is empty
                    await Toast.Make("Search term is empty", CommunityToolkit.Maui.Core.ToastDuration.Short, 12).Show();
                }
            }
            catch (Exception ex)
            {
                //Display message with error
                await Shell.Current.DisplayAlert("Error", ex.Message, "I understand");
            }
            IsBusy = false;
        }

        [RelayCommand]
        async Task ChangePage(string direction)
        {
            Vibration.Default.Vibrate(100);
            IsBusy = true;

            try
            {

                if (direction.Equals("next") && QuestionPaged.CurrentPage < QuestionPaged.Pages)
                {
                    QuestionPaged.CurrentPage++;
                    await GetQuestionsFromApi(QuestionPaged.CurrentPage);
                }
                else if (direction.Equals("previous") && QuestionPaged.CurrentPage is not 1)
                {
                    QuestionPaged.CurrentPage--;
                    await GetQuestionsFromApi(QuestionPaged.CurrentPage);
                }

            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Error", "Your internet connection seems to be a bit shaky. Try again", "I understand");
            }       
            IsBusy = false;
        }

        async Task GetQuestionsFromApi(int page)
        {

            if (Source.Equals("online"))
            {
                QuestionPaged = await apiService.GetPagedQuestions(TopicSelected.TopicRef, page, 10f);
                Questions.AddRange(QuestionPaged.Questions);

                //Questions.AddRange(await apiService.GetQuestionsSimple(TopicSelected.TopicRef));
            }
            else if (Source.Equals("offline"))
            {
                QuestionPaged = await databaseService.GetQuestionsPaged(TopicSelected.TopicRef, page, 10f);
                Questions.AddRange(QuestionPaged.Questions);

                //Questions.AddRange(databaseService.GetQuestionsAsync(TopicSelected.TopicRef));
            }
        }
    }
}
