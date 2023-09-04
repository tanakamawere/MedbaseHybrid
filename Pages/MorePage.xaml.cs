using MedbaseHybrid.ViewModels;

namespace MedbaseHybrid.Pages;

public partial class MorePage : ContentPage
{
	public MorePage(MoreViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}