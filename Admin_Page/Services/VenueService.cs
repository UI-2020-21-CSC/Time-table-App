using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_table.Admin_Page.Model;

namespace Time_table.Admin_Page.Services
{
    public class VenueService
    {   
        List<Venue> venueList = new();

        public async Task<List<Venue>> GetAllVenues()
        {
            if (venueList?.Count > 0)
                return venueList;

            // Read from venue-data.json
            using var stream = await FileSystem.OpenAppPackageFileAsync("venue-data.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            venueList = JsonSerializer.Deserialize<List<Venue>>(contents);

            return venueList;
        }
    }
}
