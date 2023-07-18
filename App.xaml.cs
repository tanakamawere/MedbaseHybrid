using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace MedbaseHybrid;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        AppCenter.Start("android=835ef564-b225-40b9-887a-23fa120e6d6b;",
                  typeof(Analytics), typeof(Crashes));

        MainPage = new MainPage();
	}
}
