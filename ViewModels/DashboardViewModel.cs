using CommunityToolkit.Mvvm.Input;
using MedbaseLibrary.Models;
using MedbaseHybrid.Pages;
using MedbaseHybrid.Services;
using MedbaseLibrary.Services;
using MvvmHelpers;

namespace MedbaseHybrid.ViewModels
{
    public partial class DashboardViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Article> Articles { get; set; } = new();
        public ObservableRangeCollection<Course> Courses { get; set; } = new();
        public DashboardViewModel(IApiRepository _apiService, IDatabaseRepository _repository)
        {
            apiService = _apiService;
            databaseService = _repository;

            AllMethods();
        }

        [RelayCommand]
        async Task AllMethods()
        {
            if (Helpers.InternetAvailable())
            {
                try
                {
                    IsBusy = true;
                    Courses.Clear();
                    Articles.Clear();

                    var caDto = await apiService.GetCourseArticlesDto();
                    Courses.AddRange(caDto.Courses);
                    Articles.AddRange(caDto.Articles);
                }
                catch (Exception ex)
                {
#if DEBUG
                    await Shell.Current.DisplayAlert("Failure!", $"{ex.Message}", "Ok");
#else
                await Shell.Current.DisplayAlert("Error", "Your internet connection seems to be a bit shaky. Try again", "I understand");
#endif
                }
                finally
                { IsBusy = false; }
            }
        }

        //Navigation Methods
        [RelayCommand]
        async Task GoToCourse(Course course)
        {
            if (course == null) return;
            await Shell.Current.GoToAsync(nameof(TopicSelectionPage), true, new Dictionary<string, object>
                {
                    {"courseSelected", course}
                });
        }
        [RelayCommand]
        static async Task GoToAllArticles() => await Browser.OpenAsync(Constants.GoToMedbaseLink("articles"));

        [RelayCommand]
        static async Task GoToArticle(Article article)
        {
            if (article == null)
                return;

            await Browser.OpenAsync(Constants.GoToMedbaseLink($"article/{article.Id}"));
        }
    }
}
