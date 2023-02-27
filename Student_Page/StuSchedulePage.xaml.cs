//using Syncfusion.Maui.ListView;
using Syncfusion.Maui.Calendar;
namespace Time_table.Student_Page
{

    public partial class StuSchedulePage : ContentPage
    {
        public StuSchedulePage()
        {
            InitializeComponent();

        }



        //this.Calendar.ViewChanged += OnCalendarViewChanged;
        private void OnDaySelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            var oldDateTime = e.OldValue;
            var newDateTime = e.NewValue;
        }

        // disable the weekend dates
        //this.Calendar.Tapped += OnCalendarTapped;
        private void OnDayTapped(object sender, CalendarTappedEventArgs e)
        {
            var selectedDate = e.Date;
            var calendarElement = e.Element;
        }
    }
}
