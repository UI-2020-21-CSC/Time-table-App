
using System.Collections.ObjectModel;
using Time_table.Services.Student;
using Time_table.Model;




namespace Time_table.ViewModel.Student
{
    public class EnlistedCoursesViewModel : BaseViewModel
    {

        public ObservableCollection<Course> Courses { get; } = new ObservableCollection<Course>();

        public Command GetCoursesCommand { get; }

        EnlistedCoursesService enlistedCoursesService;


        public EnlistedCoursesViewModel(EnlistedCoursesService coursesService)
        {
            enlistedCoursesService = coursesService;
            Title = "Enlisted Courses";
            GetCoursesCommand = new Command(async () => await GetCoursesAsync());
        }

        async Task GetCoursesAsync()
        {
            if (IsBusy)
                return;


            try
            {
                IsBusy = true;
                var courses = await enlistedCoursesService.GetCourses();

                if (Courses.Count != 0)
                    Courses.Clear();

                foreach (var course in courses)
                    Courses.Add(course);

            }
            catch (Exception ex)
            {
                //Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}

