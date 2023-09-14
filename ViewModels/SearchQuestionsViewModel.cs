using CommunityToolkit.Mvvm.ComponentModel;

namespace MedbaseHybrid.ViewModels
{
    [QueryProperty(nameof(Source), "sourceSearch")]
    public partial class SearchQuestionsViewModel : ViewModelBase
    {
        //Determine whether the questions are to be queried locally or online
        [ObservableProperty]
        string source;
    }
}
