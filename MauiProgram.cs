using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using MedbaseHybrid.Services;
using MedbaseComponents.Services;
using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;
using Plugin.MauiMTAdmob;
using MedbaseHybrid.MsalClient;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace MedbaseHybrid;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMTAdmob()
            .UseMauiCommunityToolkit()
            .UseSentry(options =>
            {
                options.Dsn = Constants.SentryDsn;
            })
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); fonts.AddFont("Montserrat-Regular.ttf", "MontRegular");
                fonts.AddFont("Montserrat-Semibold.ttf", "MontBold");
            })
			.ConfigureEssentials(essentials => 
			{
				essentials.UseVersionTracking();
			});

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudMarkdownServices();
        builder.Services.AddMudServices();
        
        builder.Services.AddScoped(sp => new HttpClient 
        {
            BaseAddress = new Uri(Constants.apiUrl)
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
        var executingAssembly = Assembly.GetExecutingAssembly();

        using var stream = executingAssembly.GetManifestResourceStream("MedbaseHybrid.appsettings.json");

        var configuration = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();



        builder.Services.AddSingleton<IApiRepository, ApiRepository>();
        builder.Services.AddSingleton<IDatabaseRepository, DatabaseRepository>();
        builder.Services.AddSingleton<IPlatformInfoService, PlatformInfoService>();
        builder.Services.AddSingleton<IPCAWrapper, PCAWrapper>();
        builder.Services.AddSingleton(Connectivity.Current);
        builder.Configuration.AddConfiguration(configuration);
        //Registering Barrel
        builder.Services.AddSingleton(FileSaver.Default);

        return builder.Build();
	}
}
