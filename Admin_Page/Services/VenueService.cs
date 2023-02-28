using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_table.Admin_Page.Model;
using Firebase.Database.Query;
using Firebase.Database;

namespace Time_table.Admin_Page.Services
{
    public class VenueService
    {   
        List<Venue> venueList = new();

        readonly FirebaseClient firebase = new FirebaseClient("https://timetable-5ec3a-default-rtdb.firebaseio.com/", new FirebaseOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult("AIzaSyCWpc9HMvOdnztiIrwAQF0NjpBQ0yEjHFk")
        });

        public async Task<List<Venue>> GetAllVenues()
        {
            if (venueList?.Count > 0)
                return venueList;

            //// Read from venue-data.json
            //using var stream = await FileSystem.OpenAppPackageFileAsync("venue-data.json");
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            //venueList = JsonSerializer.Deserialize<List<Venue>>(contents);

            //return venueList;

            return (await firebase.Child(nameof(Venue)).OnceAsync<Venue>()).Select(f => new Venue
            {
                ShortName = f.Object.ShortName,
                VenueName = f.Object.VenueName,
                Capacity = f.Object.Capacity,
                Key = f.Key,
            }).ToList();

        }
    

        public async Task<bool> AddOrEditVenue()
        {
            Venue venue = new Venue
            {
                ShortName = "FLT",
                VenueName = "Faculty Lecture Theatre",
                Capacity = 500,
                Key = ""
            };

            if (!string.IsNullOrWhiteSpace(venue.Key))
            {
                try
                {
                    await firebase.Child(nameof(Venue)).Child(venue.Key).PutAsync(venue);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                var response = await firebase.Child(nameof(Venue)).PostAsync(venue);
                if (response.Key != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public async Task<bool> DeleteVenue(string key)
        {
            try
            {
                await firebase.Child(nameof(Venue)).Child(key).DeleteAsync();
                return true;
            }
            catch (Exception ex)
            {
                // this code was added because 'ex' is not used and it raises warning in the error list
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");

                return false;
            }
        }
  
    }
}
