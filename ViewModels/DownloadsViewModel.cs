namespace MedbaseHybrid.ViewModels
{
    public partial class DownloadsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Topic> Topics { get; set; } = new();
        [ObservableProperty]
        private Topic? topicSelected;
        private IConnectivity connectivity;

        public DownloadsViewModel(IDatabaseRepository _repository, IPopupNavigation _popup, IConnectivity _connectivity)
        {
            databaseService = _repository;
            popupService = _popup;
            connectivity = _connectivity;

            loadingPopup = new();
            GetTopics();
        }

        [RelayCommand]
        void GetTopics()
        {
            IsBusy = true;
            Topics.Clear();
            Topics.AddRange(databaseService.GetTopicsAsync());
            IsBusy = false;
        }

        [RelayCommand]
        async Task TopicTapped(Topic topic)
        {
            if (topic is null) return;

            if (connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                CrossMauiMTAdmob.Current.ShowInterstitial();
                CrossMauiMTAdmob.Current.LoadInterstitial("ca-app-pub-7010150994074481/8096871111");
            }

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
