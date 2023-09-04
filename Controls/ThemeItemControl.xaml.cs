using static System.Net.Mime.MediaTypeNames;

namespace MedbaseHybrid.Controls;

public partial class ThemeItemControl : Border
{
    public static readonly BindableProperty IconProperty = BindableProperty
        .Create(nameof(Text), typeof(string), typeof(ThemeItemControl), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (ThemeItemControl)bindable;
            control.themeItemIcon.Glyph = newValue as string;
        });
    public static readonly BindableProperty TitleProperty = BindableProperty
        .Create(nameof(Title), typeof(string), typeof(ThemeItemControl), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (ThemeItemControl)bindable;
            control.themeItemLabel.Text = newValue as string;
        });
    public ThemeItemControl()
	{
		InitializeComponent();
    }
    public string Title
    {
        get => GetValue(TitleProperty) as string;
        set => SetValue(TitleProperty, value);
    }
    public string Icon
    {
        get => GetValue(IconProperty) as string;
        set => SetValue(IconProperty, value);
    }
}