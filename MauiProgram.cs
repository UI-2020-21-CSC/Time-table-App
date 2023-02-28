using Time_table.Admin_Page;
using CommunityToolkit.Maui;
using Syncfusion.Maui.Core.Hosting;
using Time_table.Services.Student;
using Time_table.ViewModel.Student;
using Time_table.ViewModel;

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

namespace Time_table
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            //Adding Syncfusion Controls
            builder.ConfigureSyncfusionCore();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).UseMauiCommunityToolkit();
            //builder.ConfigureSyncfusionListView();

            //registering with dependency injection services
            builder.Services.AddSingleton<StuScheduleService>();



            builder.Services.AddSingleton<EnlistedCoursesService>();

        // View Registration
        builder.Services.AddSingleton<VenueListPage>();
        builder.Services.AddSingleton<AdminHomePage>();
        builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<EnlistedCoursesViewModel>();
            builder.Services.AddSingleton<BaseViewModel>();
            return builder.Build();
        }
    }
}