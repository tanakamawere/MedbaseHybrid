using MedbaseHybrid.ViewModels;
using MedbaseLibrary.Models;
using MedbaseLibrary.Services;
using Mopups.Interfaces;

namespace MedbaseHybrid.Controls;

public partial class AnswersBottomSheet
{
	public AnswersBottomSheet(IApiRepository apiRepository ,Question question, IPopupNavigation popupNavigation)
	{
		InitializeComponent();
        BindingContext = new AnswersSheetViewModel(apiRepository, question, popupNavigation, this);
    }
}