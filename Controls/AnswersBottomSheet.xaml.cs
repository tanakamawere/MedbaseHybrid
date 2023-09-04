using Markdig;
using MedbaseLibrary.Models;

namespace MedbaseHybrid.Controls;

public partial class AnswersBottomSheet
{
	public AnswersBottomSheet(Question question)
	{
		InitializeComponent();

        TitleLabel.Text = string.Join(". ", question.Id, question.QuestionMain);

        StemA.Text = "a. " + question.ChildA + "\n";
        StemB.Text = "b. " + question.ChildB + "\n";
        StemC.Text = "c. " + question.ChildC + "\n";
        StemD.Text = "d. " + question.ChildD + "\n";
        StemE.Text = "e. " + question.ChildE + "\n";
        AnswerA.Text = question.AnswerA.ToString();
        AnswerB.Text = question.AnswerB.ToString();
        AnswerC.Text = question.AnswerC.ToString();
        AnswerD.Text = question.AnswerD.ToString();
        AnswerE.Text = question.AnswerE.ToString();
    }
}