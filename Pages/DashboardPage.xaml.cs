using MedbaseHybrid.ViewModels;

namespace MedbaseHybrid.Pages;

public partial class DashboardPage : ContentPage
{
	public DashboardPage(DashboardViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}