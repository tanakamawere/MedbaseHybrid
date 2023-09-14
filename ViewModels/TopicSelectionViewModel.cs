using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MedbaseLibrary.Models;
using MedbaseHybrid.Pages;
using MedbaseHybrid.Services;
using MedbaseLibrary.Services;
using Mopups.Interfaces;
using CommunityToolkit.Maui.Alerts;
using Plugin.MauiMTAdmob;

namespace MedbaseHybrid.ViewModels
{
    [QueryProperty(nameof(CourseSelected), "courseSelected")]
    public partial class TopicSelectionViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Course courseSelected;
        [ObservableProperty]
        private IEnumerable<Topic> topics;

        public TopicSelectionViewModel(IApiRepository _apiService, IDatabaseRepository _repo, IPopupNavigation _popup)
        {
            apiService = _apiService;
            databaseService = _repo;
            popupService = _popup;

            loadingPopup = new();
        }

        [RelayCommand]
        public async Task Refresh()
        {
            IsBusy = true;
            if (CourseSelected == null) return;

            try
            {
                Topics = await apiService.GetTopics(CourseSelected.CourseRef);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Your internet connection seems to be a bit shaky. Try again", "I understand");
            }

            IsBusy = false;
        }

        //[RelayCommand]
        //static async Task CreateQuiz(Topic topic)
        //{
        //    if (topic is null) return;

        //    try
        //    {
        //        await Shell.Current.ShowPopupAsync(new CustomiseQuizPopup(topic, "online"));
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //}

        [RelayCommand]
        async Task ViewAll(Topic topic)
        {
            if (topic is null) return;


            await Shell.Current.GoToAsync(nameof(QuestionsPage), true, new Dictionary<string, object>
            {
                {"topicSelected", topic },
                {"sourceFromTopic", "online" }
            });
        }
        [RelayCommand]
        async Task Download(Topic topic)
        {
            if (topic is null) return;

            try
            {
                await popupService.PushAsync(loadingPopup);
                if (CheckIfAlreadyDownloaded(topic) == false)
                    await DownloadMethod(topic);
                else
                    await Shell.Current.DisplayAlert("Already downloaded", "Your requested topic is already downloaded on your device", "Ok");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await popupService.PopAsync();
            }
        }
        async Task DownloadMethod(Topic topic)
        {
            await databaseService.SaveTopicAndQuestionsAsync(await apiService.GetQuestionsSimple(topic.TopicRef), topic);
            await Toast.Make($"{topic.Name} has been downloaded. Go check it out in your downloads", CommunityToolkit.Maui.Core.ToastDuration.Long, 12).Show();
        }
        bool CheckIfAlreadyDownloaded(Topic topic)
        {
            List<Topic> downloadedTopics = databaseService.GetTopicsAsync().ToList();
            bool downloaded = false;
            Topic topicFound = downloadedTopics.Where(x => x.Name == topic.Name).FirstOrDefault();

            if (topicFound is not null)
            {
                downloaded = true;
            }
            return downloaded;
        }
    }
}