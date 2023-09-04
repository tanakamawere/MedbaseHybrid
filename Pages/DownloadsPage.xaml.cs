using MedbaseHybrid.ViewModels;

namespace MedbaseHybrid.Pages;

public partial class DownloadsPage : ContentPage
{
	public DownloadsPage(DownloadsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}