using Firebase.Auth;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lecturer;
using Time_table.Student_Page;

namespace Time_table
{
    public partial class RegisterPage : ContentPage
    {
        private readonly RegisterViewModel _viewModel;

        public RegisterPage()
        {
            InitializeComponent();

            _viewModel = new RegisterViewModel();
            BindingContext = _viewModel;
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var userType = _viewModel.SelectedUserType;
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            var confirmPassword = ConfirmPasswordEntry.Text;
            var email = EmailEntry.Text;

            if (string.IsNullOrEmpty(userType))
            {
                await DisplayAlert("Error", "Please select a user type.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Error", "Please enter all registration fields.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Password and confirmation password do not match.", "OK");
                return;
            }

            try
            {
                // Create new user in Firebase Authentication
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCWpc9HMvOdnztiIrwAQF0NjpBQ0yEjHFk"));
                var authResult = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);

                // Save registration data to Firebase Realtime Database using REST API
                var client = new HttpClient();
                var json = new Dictionary<string, object>
                {
                    {"username", username},
                    {"email", email},
                    {"userType", userType}
                };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(json), System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync($"https://timetable-5ec3a-default-rtdb.firebaseio.com/{userType}s/{authResult.User.LocalId}.json", content);

                // Display success message
                await DisplayAlert("Registration Complete", "Your account has been created successfully.", "OK");
                await Navigation.PushAsync(new LoginPage());

                // Navigate to appropriate page based on user type

            }
            catch (FirebaseAuthException ex)
            {
                // Handle authentication errors
                if (ex.Reason == AuthErrorReason.EmailExists)
                {
                    await DisplayAlert("Error", "The email address is already in use.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", ex.Reason.ToString(), "OK");
                }
            }
        }

        public class RegisterViewModel : BindableObject
        {
            private List<string> _userTypes = new() { "Lecturer", "Student" };
            private string _selectedUserType;

            public List<string> UserTypes
            {
                get { return _userTypes; }
                set { _userTypes = value; OnPropertyChanged(); }
            }

            public string SelectedUserType
            {
                get { return _selectedUserType; }
                set { _selectedUserType = value; OnPropertyChanged(); }
            }

            protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public new event PropertyChangedEventHandler PropertyChanged;
        }
    }
}