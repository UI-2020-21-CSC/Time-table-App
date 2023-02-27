using Time_table.Model;
using System.Text.Json;
using System.Net.Http.Json;
namespace Time_table.Services.Student
{
    public class StuScheduleService
    {
        HttpClient httpClient;

        List<Course> courseList = new List<Course>();
        Dictionary<string, List<Course>> schedule = new Dictionary<string, List<Course>>();
        public StuScheduleService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Course>> GetDailyCourses(string dayOfTheWeek)
        {
            //Online get request will be made to the backend to fetch the data asynchronously
            /*
            var url = "https://neugott.com/courses.json";

            var response = await httpClient.GetAsync(url);

            if ( response.IsSuccessStatusCode)
            {
                courseList = await response.Content.ReadFromJsonAsync<List<Course>>();
            }
            */

            // Offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("StuScheduleCourses.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            schedule = JsonSerializer.Deserialize<Dictionary<string, List<Course>>>(contents);

            // learn how to work with dictionary in C#
            if (schedule.ContainsKey(dayOfTheWeek))
            { }
            return courseList;
        }
    }
}

