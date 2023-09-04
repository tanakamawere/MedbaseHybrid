using MedbaseHybrid.ViewModels;

namespace MedbaseHybrid.Pages;

public partial class QuestionsPage : ContentPage
{
	private QuestionsViewModel viewModel => BindingContext as QuestionsViewModel;
	public QuestionsPage(QuestionsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}