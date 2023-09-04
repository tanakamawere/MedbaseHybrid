using MedbaseHybrid.ViewModels;

namespace MedbaseHybrid.Pages;

public partial class TopicSelectionPage : ContentPage
{
	private TopicSelectionViewModel vm => BindingContext as TopicSelectionViewModel;
	public TopicSelectionPage(TopicSelectionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.Refresh();
    }
}