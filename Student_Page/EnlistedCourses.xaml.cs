using Time_table.ViewModel.Student;
using Time_table.Services.Student;



namespace Time_table.Student_Page;

public partial class EnlistedCourses : ContentPage
{
    public EnlistedCourses()
    {
        InitializeComponent();
        EnlistedCoursesService service = new EnlistedCoursesService();
        EnlistedCoursesViewModel viewModel = new EnlistedCoursesViewModel(service);
        BindingContext = viewModel;
    }
}