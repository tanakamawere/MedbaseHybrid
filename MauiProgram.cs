using MudBlazor.Services;

namespace MedbaseHybrid;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiMTAdmob()
            .ConfigureMopups()
            .UseBottomSheet()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); fonts.AddFont("Montserrat-Regular.ttf", "MontRegular");
                fonts.AddFont("Montserrat-Semibold.ttf", "MontBold");
                fonts.AddFont("faregular.otf", "faregular");
                fonts.AddFont("fasolid.otf", "fasolid");
                fonts.AddFont("fabrands.otf", "fabrands");
            })
			.ConfigureEssentials(essentials => 
			{
				essentials.UseVersionTracking();
			});

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddMudServices();
        builder.Services.AddSingleton(MopupService.Instance);
        builder.Services.AddScoped(sp => new HttpClient 
        {
            BaseAddress = new Uri(Constants.apiUrl)
        });

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<IApiRepository, ApiRepository>();
        builder.Services.AddSingleton<IDatabaseRepository, DatabaseRepository>();
        builder.Services.AddSingleton(Connectivity.Current);
        //Registering Barrel
        Barrel.ApplicationId = Constants.ApplicationId();
        builder.Services.AddSingleton(Barrel.Current);


        //Pages & Popups
        builder.Services.AddSingleton<DashboardPage>();
        builder.Services.AddSingleton<DownloadsPage>();
        builder.Services.AddTransient<TopicSelectionPage>();
        builder.Services.AddTransient<QuestionsPage>();
        builder.Services.AddTransient<MorePage>();
        builder.Services.AddTransient<ExportImagePage>();


        //ViewModels
        builder.Services.AddSingleton<DashboardViewModel>();
        builder.Services.AddTransient<DownloadsViewModel>();
        builder.Services.AddTransient<TopicSelectionViewModel>();
        builder.Services.AddTransient<AnswersSheetViewModel>();
        builder.Services.AddTransient<CorrectionsPopupViewModel>();
        builder.Services.AddTransient<QuestionsViewModel>();
        builder.Services.AddTransient<MoreViewModel>();
        builder.Services.AddTransient<ExportImageViewModel>();

        builder.Services.AddSingleton(FileSaver.Default);

        return builder.Build();
	}
}
