using CommunityToolkit.Mvvm.Input;
using MedbaseLibrary.Models;
using MedbaseHybrid.Pages;
using MedbaseHybrid.Services;
using Mopups.Interfaces;
using MvvmHelpers;
using System.Diagnostics;

namespace MedbaseHybrid.ViewModels
{
    public partial class DownloadsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Topic> Topics { get; set; } = new();

        public DownloadsViewModel(IDatabaseRepository _repository, IPopupNavigation _popup)
        {
            databaseService = _repository;
            popupService = _popup;


            loadingPopup = new();
            GetTopics();
        }

        [RelayCommand]
        async Task GetTopics()
        {
            Topics.Clear();
            Topics.AddRange(databaseService.GetTopicsAsync());
        }

        //View clicks
        //[RelayCommand]
        //static async Task CreateQuiz(Topic topic)
        //{
        //    if (topic is null) return;

        //    try
        //    {
        //        await Shell.Current.ShowPopupAsync(new CustomiseQuizPopup(topic, "offline"));
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
                {"sourceFromTopic", "offline" }
            });
        }

        [RelayCommand]
        async Task Delete(Topic topic)
        {
            if (topic is null) return;

            try
            {
                await databaseService.DeleteTopicAsync(topic.TopicRef);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Debug.WriteLine(ex.InnerException.Message);
            }
            finally
            {
                GetTopics();
            }
        }
    }
}
