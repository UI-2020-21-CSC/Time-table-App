


using Time_table.Model;
using System.Text.Json;



namespace Time_table.Services.Student;

public class EnlistedCoursesService
{
    HttpClient httpClient;

    List<Course> courseList = new List<Course>();

    public EnlistedCoursesService()
    {
        httpClient = new HttpClient();
    }

    public async Task<List<Course>> GetCourses()
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
        using var stream = await FileSystem.OpenAppPackageFileAsync("EnlistedCourses.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        courseList = JsonSerializer.Deserialize<List<Course>>(contents);

        return courseList;
    }
}
