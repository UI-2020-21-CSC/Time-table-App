using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_table.Admin_Page.ViewModel
{
    public partial class AdminHomePageViewModel: ObservableObject
    {
        [ObservableProperty]
        string title;

        public AdminHomePageViewModel()
        {
            Title = "Admin Home Page";
        }

        //[RelayCommand]
        //async Task AddCourseCommand()
        //{
        //    await Shell.Current.GoToAsync(nameof(VenueListPage));
        //    //var viewModel = new VenueListPageViewModel();
        //    //var adminHomePage = new StudentListPage(viewModel);
        //    //await Navigation.PushAsync(adminHomePage);
        //}
    }
}
