using MedbaseHybrid.ViewModels;

namespace MedbaseHybrid.Pages;

public partial class ExportImagePage : ContentPage
{
	public ExportImagePage(ExportImageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;	
	}
}