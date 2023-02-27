using Time_table.ViewModel.Student;

namespace Time_table.Student_Page;

public partial class EnlistedCourses : ContentPage
{
    public EnlistedCourses(EnlistedCoursesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}