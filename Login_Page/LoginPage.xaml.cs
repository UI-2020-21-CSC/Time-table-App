// Import necessary libraries
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Lecturer;
using Time_table.Admin_Page;
using Time_table.Student_Page;
// Define the namespace
namespace Time_table
{
    // Define a partial class called LoginPage
    public partial class LoginPage : ContentPage
    {
        // Define a Firebase client object to interact with Firebase
        private readonly FirebaseClient firebaseClient;
        // Constructor method for LoginPage class
        public LoginPage()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient("https://timetable-5ec3a-default-rtdb.firebaseio.com/");
        }
          // Event handler for the login button click
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                 // Get the email and password entered by the user
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                  // Validate user input
                if (string.IsNullOrEmpty(email))
                {
                    await DisplayAlert("Error", "You must enter an email.", "OK");
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    await DisplayAlert("Error", "You must enter a password", "OK");
                    return;
                }

                if (!email.Contains('@'))
                {
                    await DisplayAlert("Error", "Email must include @", "OK");
                    return;
                }
                // Authenticate the user using Firebase authentication
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCWpc9HMvOdnztiIrwAQF0NjpBQ0yEjHFk"));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                // Check the user type and navigate to the appropriate page
                var StuUserType = await firebaseClient.Child("Students").Child(auth.User.LocalId).Child("userType").OnceSingleAsync<string>();
                var LecUserType = await firebaseClient.Child("Lecturers").Child(auth.User.LocalId).Child("userType").OnceSingleAsync<string>();

                if (email == "admin@user.com" && password == "123456")
                {
                    // Navigate to the VenueListPage for the admin user
                    //await Shell.Current.GoToAsync("VenueListPage");
                    var venueService = new VenueService();
                    var viewModel = new VenueListPageViewModel(venueService);
                    var venueListPage = new VenueListPage(viewModel);
                    await Navigation.PushAsync(venueListPage); 
                    
                    // Alternatively, navigate to the AdminHomePage
                    //var viewModel = new AdminHomePageViewModel();
                    //var adminHomePage = new AdminHomePage(viewModel);
                    //await Navigation.PushAsync(adminHomePage);

                    // Or, navigate to the AdminHomePage directly
                    //await Navigation.PushAsync(new AdminHomePage());
                }
                else if (StuUserType == "Student")
                {   
                     // Navigate to the StuHomePage for the student user
                    await Navigation.PushAsync(new StuHomePage());
                }
                else if (LecUserType == "Lecturer")
                {   
                     // Navigate to the MainPage for the lecturer user
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {   
                    // If the user type is not recognized, display an error message
                    await DisplayAlert("Error", "User does not exist", "OK");
                }

            }
            catch (FirebaseAuthException ex)
            {   
                 // Handle authentication-related errors
                switch (ex.Reason)
                {
                    //these are all test cases for handler
                    case AuthErrorReason.WrongPassword:
                        await DisplayAlert("Error", "Invalid password.", "OK");
                        break;
                    case AuthErrorReason.UnknownEmailAddress:
                    case AuthErrorReason.InvalidEmailAddress:
                        await DisplayAlert("Error", "Email not found.", "OK");
                        break;
                    case AuthErrorReason.Undefined:
                        await DisplayAlert("Error", "Internet connection required.", "OK");
                        break;
                    default:
                        await DisplayAlert("Error", ex.Message, "OK");
                        break;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private async void Forgot_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PasswordPage());
        }
    }
}
