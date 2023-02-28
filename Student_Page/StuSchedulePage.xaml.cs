//using Syncfusion.Maui.ListView;
using Syncfusion.Maui.Calendar;
using Time_table.ViewModel.Student;
using Time_table.Services.Student;



namespace Time_table.Student_Page
{

    public partial class StuSchedulePage : ContentPage
    {

        public StuSchedulePage()
        {
            InitializeComponent();
            StuScheduleService service = new StuScheduleService();
            StuScheduleViewModel viewModel = new StuScheduleViewModel(service);


            Calendar.Tapped += (object sender, CalendarTappedEventArgs e) =>
            {
                viewModel.GetDailyCoursesCommand.Execute(e.Date.ToString("dddd"));
            };

            BindingContext = viewModel;

        }



        //this.Calendar.ViewChanged += OnCalendarViewChanged;
        private void OnDaySelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            var oldDateTime = e.OldValue;
            var newDateTime = e.NewValue;
        }

        // disable the weekend dates
        //this.Calendar.Tapped += OnCalendarTapped;
        /*
        private void OnDayTapped(object sender, CalendarTappedEventArgs e)
        {
            // getting the day tapped
            var selectedDate = e.Date;
            string dayOfTheWeek = selectedDate.ToString("dddd");
            var calendarElement = e.Element;
        }
        */
    }
}
