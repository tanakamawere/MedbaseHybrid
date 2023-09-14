using MedbaseHybrid.ViewModels;

namespace MedbaseHybrid.Pages;

public partial class SearchQuestionsPage : ContentPage
{
	public SearchQuestionsPage(SearchQuestionsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}