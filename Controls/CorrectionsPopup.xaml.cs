using MedbaseHybrid.ViewModels;
using MedbaseLibrary.Models;
using MedbaseLibrary.Services;
using Mopups.Interfaces;

namespace MedbaseHybrid.Controls;

public partial class CorrectionsPopup
{
	public CorrectionsPopup(IApiRepository repository, Question question, IPopupNavigation navigation)
	{
		InitializeComponent();
		BindingContext = new CorrectionsPopupViewModel(repository, question, navigation);
	}
}