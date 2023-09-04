using static System.Net.Mime.MediaTypeNames;

namespace MedbaseHybrid.Controls;

public partial class SocialsItemControl : Border
{
    public static readonly BindableProperty IconProperty = BindableProperty
        .Create(nameof(Text), typeof(string), typeof(SocialsItemControl), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (SocialsItemControl)bindable;
            control.socialItemIcon.Glyph = newValue as string;
        });
    public static readonly BindableProperty TitleProperty = BindableProperty
        .Create(nameof(Title), typeof(string), typeof(SocialsItemControl), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (SocialsItemControl)bindable;
            control.socialItemLabel.Text = newValue as string;
        });
    public SocialsItemControl()
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