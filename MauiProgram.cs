using Time_table.Admin_Page;
using CommunityToolkit.Maui;

//using Time_table.Admin_Page.Services;
//using Time_table.Admin_Page.View;
namespace Time_table;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        
        // Services
        builder.Services.AddSingleton<VenueService>();


        // ViewModel registration
        builder.Services.AddSingleton<VenueListPageViewModel>();
        builder.Services.AddSingleton<AdminHomePageViewModel>();

        // View Registration
        builder.Services.AddSingleton<VenueListPage>();
        builder.Services.AddSingleton<AdminHomePage>();
        builder.Services.AddSingleton<LoginPage>();
        return builder.Build();
    }
}