using Syncfusion.Maui.Core.Hosting;
using Time_table.Services.Student;
using Time_table.ViewModel.Student;
using Time_table.ViewModel;
using CommunityToolkit.Maui;


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

            builder.Services.AddSingleton<EnlistedCoursesViewModel>();
            builder.Services.AddSingleton<BaseViewModel>();
            return builder.Build();
        }
    }
}