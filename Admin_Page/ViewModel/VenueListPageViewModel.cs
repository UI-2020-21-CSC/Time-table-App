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

        [RelayCommand]
        async Task AddOrEditVenueAsync(Venue venue)
        {
            if (IsVenueLoading) return;

            try
            {
                IsVenueLoading = true;

                bool success = await venueService.AddOrEditVenue();

                if (success)
                {
                    var venues = await venueService.GetAllVenues();

                    if (Venues.Count != 0) Venues.Clear();

                    foreach(Venue eachVenue in venues)
                    {
                        Venues.Add(eachVenue);
                    }
                }
                else
                {
                    // Display Alert;
                    //await DisplayAlert("Error", "Invalid password.", "OK");
                    Console.WriteLine("Failed to add or edit venue");
                }

            }catch (Exception e)
            {
                // Display Alert
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                IsVenueLoading = false;
            }
        }


        [RelayCommand]
        async Task DeleteAsync(Venue venue)
        {
            if (IsVenueLoading) return;

            try
            {
                IsVenueLoading = true;

                bool success = await venueService.DeleteVenue(venue.Key);

                if (success)
                {
                    var venues = await venueService.GetAllVenues();

                    if (Venues.Count != 0) Venues.Clear();

                    foreach (Venue eachVenue in venues)
                    {
                        Venues.Add(eachVenue);
                    }
                }
                else
                {
                    // Display Alert;
                    //await DisplayAlert("Error", "Invalid password.", "OK");
                    Console.WriteLine("Failed to delete venue");
                }

            }
            catch (Exception e)
            {
                // Display Alert
                Console.WriteLine("Exception: {0}", e.Message);
            }
            finally
            {
                IsVenueLoading = false;
            }
        }

    }
}
