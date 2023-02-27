# Creating a Mobile Timetable App with .NET MAUI and Firebase
## Introduction:
In this repository, we will create a mobile timetable app using .NET Multi-platform App UI (MAUI) and Firebase for authentication and database management. .NET MAUI is a new framework from Microsoft that allows you to create cross-platform mobile apps for Android, iOS, and Windows with a single codebase. Firebase is a cloud-based platform that provides services such as authentication, real-time database, and cloud storage.

### Prerequisites:
* Basic knowledge of .NET programming.
* Visual Studio 2022 with .NET MAUI workload installed.
* A Firebase account.

### Link to some resources
* The [FIGMA DESIGN](https://www.figma.com/file/ybQcFsvDKJn2cyzCmBGVux/Timetable-App?node-id=0%3A1&t=jjw49eyIGauyOk8y-1) in mind for the project was made to help users interact well with the app and retain attention 
* [Getting Started with .NET MAUI](https://docs.microsoft.com/en-us/dotnet/maui/get-started/)
* [.NET MAUI and Blazor: The Future of Cross-Platform Development?](https://visualstudiomagazine.com/articles/2022/02/01/maui-blazor.aspx)
* [How to Build a Weather App in .NET MAUI](https://www.telerik.com/blogs/how-to-build-a-weather-app-in-dot-net-maui)
* [.NET MAUI: What's New in Preview 8](https://www.infoq.com/news/2022/02/dotnet-maui-preview8/)
* [Building a Xamarin Forms App with .NET 6 and Maui Compatibility](https://www.c-sharpcorner.com/article/building-a-xamarin-forms-app-with-net-6-and-maui-compatibility/)


### Steps:
1. Create a new .NET MAUI project in Visual Studio 2022.
2. Install the Firebase Authentication and Firebase Realtime Database NuGet packages in the project.
3. Configure Firebase in the project by adding the Firebase configuration file to the project. The configuration file can be downloaded from the Firebase console.
4. Implement Firebase authentication in the project by adding the necessary code to the LoginPage.xaml.cs file.
5. Create the necessary models and views for the app, including the login page, registration page, and timetable page.
6. Implement the Firebase Realtime Database in the project by adding the necessary code to read and write data to the database.
7. Add navigation between the pages of the app.
8. Test the app on Android and iOS devices.

## Implementation Details:
1. Create a new .NET MAUI project in Visual Studio 2022:
   - Open Visual Studio 2022 and select "Create a new project".
   - Choose "Mobile App (Multi-Platform)" and click "Next".
   - Choose "MAUI" and click "Create".
   - Give the project a name and click "Create".
2. Install the Firebase Authentication and Firebase Realtime Database NuGet packages in the project:
   - Right-click on the project in the Solution Explorer and select "Manage NuGet Packages".
   - Search for "Firebase.Auth" and "Firebase.Database" and install them.
3. Configure Firebase in the project:
   - Go to the Firebase console and create a new project.
   - Click "Add app" and select "Android" or "iOS", depending on your target platform.
   - Follow the instructions to add the Firebase configuration file to your project.
   - Repeat the process for the other platform, if necessary.
4. Implement Firebase authentication in the project:
   - Open the LoginPage.xaml.cs file.
   - Add the necessary using statements for Firebase Authentication and Firebase Realtime Database.
   - In the LoginPage constructor, create a new FirebaseClient object and pass in the URL of your Firebase Realtime Database.
   - In the Button_Clicked event handler, add the code to authenticate the user with Firebase by calling the SignInWithEmailAndPasswordAsync method of the FirebaseAuthProvider class.
   - Add code to read the user type from the Firebase Realtime Database and navigate to the appropriate page based on the user type.
5. Create the necessary models and views for the app:
   - Create the necessary model classes for the app, such as User, Timetable, etc.
   - Create the necessary views for the app, including the login page, registration page, and timetable page.
6. Implement the Firebase Realtime Database in the project:
   - In the constructor of the relevant view, create a new FirebaseClient object and pass in the URL of your Firebase Realtime Database.
   - Use the FirebaseClient object to read and write data to the Firebase Realtime Database.
7. Add navigation between the pages of the app:
   - Use the Navigation.PushAsync method to navigate between the pages of the app.
8. Test the app on Android and iOS devices:
   - Deploy the app to Android and iOS devices for testing.


### The psuedo-code for some major processes
#### Logging in users 
  * Create a FirebaseClient object and set it to the URL of your Firebase Realtime Database.
  * In the button click event, get the email and password entered by the user.
  * Check if the email and password are not empty. If they are empty, display an error message and return.
  * Check if the email contains an '@' symbol. If it does not, display an error message and return.
  * Use the FirebaseAuthProvider object to sign in with the email and password entered by the user. If the sign-in fails, catch the FirebaseAuthException and display an error message based on the exception's Reason property.  
  * If the sign-in is successful, use the Firebase Realtime Database to get the user type of the signed-in user.
  * If the signed-in user is an admin, navigate to the admin home page.
  * If the signed-in user is a student, navigate to the student home page.
  * If the signed-in user is a lecturer, navigate to the lecturer home page.
  * If the signed-in user is not recognized, display an error message.

#### Getting the course's a user is taking
  * Retrieve the student's course list from the database using their user ID.
  * Check if the course to be assigned is already in the student's course list.
  * If the course is already in the list, display an error message and return.
  * If the course is not in the list, add it to the course list in the database.
    ### Code snippet 
    ````
      string courseId = "CSCI101"; // Example course ID
      string studentId = "abc123"; // Example student ID

      // Retrieve the student's course list from the database
      var courseList = await firebaseClient.Child("Students").Child(studentId).Child("courses").OnceSingleAsync<List<string>>();

      // Check if the course is already in the student's course list
      if (courseList.Contains(courseId))
      {
         await DisplayAlert("Error", "Course already assigned.", "OK");
         return;
      }

      // Add the course to the student's course list in the database
      courseList.Add(courseId);
      await firebaseClient.Child("Students").Child(studentId).Child("courses").PutAsync(courseList);
      ````

#### Adding a new course to the course list in the database
  * Get the course data that needs to be added to the course section.
  * Add the course data to the course section of the database in Firebase.
    ### Code snippet 
    ````
      // Get a reference to the course section of the database
      var courseSectionRef = firebaseClient.Child("CourseSection");

      // Get the course data that needs to be added
      var courseData = new Course
      {
         CourseCode = "COMP1001",
         CourseName = "Introduction to Computer Science",
         Instructor = "John Doe"
      };

      // Add the course data to the course section of the database
      await courseSectionRef.PostAsync(courseData);
    ````

#### Creating the timetable object 
  * Create a FirebaseClient object and set it to the URL of your Firebase Realtime Database.
  * Get the course code, lecture hall, date, and time period entered by the user.
  * Create a new object to represent the timetable.
  * Set the properties of the timetable object with the data entered by the user. 
  * Use the Firebase Realtime Database to add the timetable object to the Timetable section of the database.
  ### Code snippets
      ````
      private async void CreateTimetableButton_Clicked(object sender, EventArgs e)
      {
         try
         {
            // Get the course code, lecture hall, date, and time period entered by the user.
            string courseCode = courseCodeEntry.Text;
            string lectureHall = lectureHallEntry.Text;
            string date = datePicker.Date.ToString("dd-MM-yyyy");
            string startTime = startTimePicker.Time.ToString("hh\\:mm");
            string endTime = endTimePicker.Time.ToString("hh\\:mm");

            // Create a new timetable object.
            var timetable = new Timetable
            {
                  CourseCode = courseCode,
                  LectureHall = lectureHall,
                  Date = date,
                  StartTime = startTime,
                  EndTime = endTime,
                  OccursToday = true // Set to true by default
            };

            // Use the Firebase Realtime Database to add the timetable object to the Timetable section of the database.
            await firebaseClient.Child("Timetable").PostAsync(timetable);

            await DisplayAlert("Success", "Timetable created successfully", "OK");
         }
         catch (Exception ex)
         {
            await DisplayAlert("Error", ex.Message, "OK");
         }
      }
       ```` 


## Conclusion:
