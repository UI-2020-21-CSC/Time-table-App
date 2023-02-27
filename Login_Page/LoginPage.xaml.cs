using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Lecturer;
using Time_table.Admin_Page;
using Time_table.Student_Page;

namespace Time_table
{
    public partial class LoginPage : ContentPage
    {
        private readonly FirebaseClient firebaseClient;

        public LoginPage()
        {
            InitializeComponent();
            firebaseClient = new FirebaseClient("https://timetable-5ec3a-default-rtdb.firebaseio.com/");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtPassword.Text;

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

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCWpc9HMvOdnztiIrwAQF0NjpBQ0yEjHFk"));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

                var StuUserType = await firebaseClient.Child("Students").Child(auth.User.LocalId).Child("userType").OnceSingleAsync<string>();
                var LecUserType = await firebaseClient.Child("Lecturers").Child(auth.User.LocalId).Child("userType").OnceSingleAsync<string>();

                if (email == "admin@user.com" && password == "123456")
                {
                    //await Shell.Current.GoToAsync("VenueListPage");
                    var venueService = new VenueService();
                    var viewModel = new VenueListPageViewModel(venueService);
                    var venueListPage = new VenueListPage(viewModel);
                    await Navigation.PushAsync(venueListPage); 
                    
                    //var viewModel = new AdminHomePageViewModel();
                    //var adminHomePage = new AdminHomePage(viewModel);
                    //await Navigation.PushAsync(adminHomePage);

                    //await Navigation.PushAsync(new AdminHomePage());
                }
                else if (StuUserType == "Student")
                {
                    await Navigation.PushAsync(new StuHomePage());
                }
                else if (LecUserType == "Lecturer")
                {
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Error", "User does not exist", "OK");
                }

            }
            catch (FirebaseAuthException ex)
            {
                switch (ex.Reason)
                {
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
