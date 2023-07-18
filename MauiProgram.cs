using Microsoft.Extensions.Logging;
using MedbaseHybrid.Repositories;
using MedbaseHybrid.Services;
using MudBlazor.Services;
using CommunityToolkit.Maui;

namespace MedbaseHybrid;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			})
			.ConfigureEssentials(essentials => 
			{
				essentials.UseVersionTracking();
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
        builder.Services.AddMudServices();
        builder.Services.AddSingleton<IApiRepository, ApiRepository>();
		builder.Services.AddSingleton<IDatabaseRepository, DatabaseRepository>();

		return builder.Build();
	}
}
