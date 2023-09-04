namespace MedbaseHybrid.Controls;

public partial class SettingsItemControl : ContentView
{
	public readonly static BindableProperty TitleProperty = BindableProperty
		.Create(nameof(Title), typeof(string), typeof(SettingsItemControl));


	public string Title
	{
		get => GetValue(TitleProperty) as string;
		set => SetValue(TitleProperty, value);
	}
	public SettingsItemControl()
	{
		InitializeComponent();
	}
}