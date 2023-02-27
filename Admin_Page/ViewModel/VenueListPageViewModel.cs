using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_table.Admin_Page.Model;
using Time_table.Admin_Page.Services;

namespace Time_table.Admin_Page.ViewModel
{
    public partial class VenueListPageViewModel:ObservableObject
    {
        // Goal here is to create all the member variables that will be needed here
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsVenueNotLoading))]
        bool isVenueLoading;

        [ObservableProperty]
        string title;

        public bool IsVenueNotLoading => !IsVenueLoading;
        // Connect this ViewModel to the service that will be fecthing all the Venues

        // Declare a collection that has the power to update the view when new venues are added or deleted
        public ObservableCollection<Venue> Venues { get; set; } = new();

        // Create an instance of the venueService to call methods from it
        VenueService venueService;

        public VenueListPageViewModel(VenueService venueService)
        {
            this.venueService = venueService;
            Title = "All The Venues In The  World";
        }

        [RelayCommand]
        async Task GetVenuesAsync()
        {
            if (IsVenueLoading) return;

            try
            {
                IsVenueLoading = true;
                var venues = await venueService.GetAllVenues();

                if (Venues.Count != 0) Venues.Clear();

                foreach (var venue in venues)
                {
                    Venues.Add(venue);
                }
            } 
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", $"Unable to get venues: {ex.Message}", "OK");
            }
            finally
            {
                IsVenueLoading = false;

            }
        }

    }
}
