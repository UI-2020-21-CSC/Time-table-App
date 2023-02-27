using Time_table.Services.Student;
using Time_table.ViewModel.Student;

namespace Time_table.Student_Page;

public partial class StuHomePage : ContentPage
{
    public StuHomePage()
    {
        InitializeComponent();
    }

    private void OnHomeClicked(object sender, EventArgs e)
    {
        // Go to the student home page
        Navigation.PushAsync(new Student_Page.StuHomePage());

    }
    private void OnScheduleClicked(object sender, EventArgs e)
    {
        // Go to the student schedule page
        Navigation.PushAsync(new Student_Page.StuSchedulePage());

    }



    private void OnEnlistedCoursesClicked(object sender, EventArgs e)
    {
        // Go to the student enlisted courses page
        StuScheduleService service = new StuScheduleService();
        EnlistedCoursesViewModel viewModel = new EnlistedCoursesViewModel(service);
        Navigation.PushAsync(new Student_Page.EnlistedCourses(viewModel));

    }
}

