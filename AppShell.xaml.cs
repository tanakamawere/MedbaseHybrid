using MedbaseHybrid.Pages;

namespace MedbaseHybrid;

public partial class AppShell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        Routing.RegisterRoute(nameof(QuestionsPage), typeof(QuestionsPage));
        Routing.RegisterRoute(nameof(DownloadsPage), typeof(DownloadsPage));
        Routing.RegisterRoute(nameof(TopicSelectionPage), typeof(TopicSelectionPage));
        Routing.RegisterRoute(nameof(MorePage), typeof(MorePage));
        Routing.RegisterRoute(nameof(ExportImagePage), typeof(ExportImagePage));
    }
}