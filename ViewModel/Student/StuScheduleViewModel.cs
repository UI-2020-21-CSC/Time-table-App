
using System.Collections.ObjectModel;
using Time_table.Services.Student;
using Time_table.Model;


namespace Time_table.ViewModel.Student
{
    public class StuScheduleViewModel : BaseViewModel
    {

        public ObservableCollection<Course> Courses { get; } = new ObservableCollection<Course>();

        public Command GetDailyCoursesCommand { get; }

        StuScheduleService dailyCoursesService;


        public StuScheduleViewModel(StuScheduleService coursesService)
        {

            dailyCoursesService = coursesService;
            Title = "Schedule";
            GetDailyCoursesCommand = new Command<string>(async parameter => await GetDailyCoursesAsync(parameter));
        }

        async Task GetDailyCoursesAsync(string dayOfTheWeek)
        {
            if (IsBusy)
                return;


            try
            {
                IsBusy = true;
                var courses = await dailyCoursesService.GetDailyCourses(dayOfTheWeek);

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
