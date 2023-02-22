namespace Time_table;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;
        string email = EmailEntry.Text;

        // Validate the input.
        if (string.IsNullOrWhiteSpace(username))
        {
            await DisplayAlert("Error", "You must enter a username.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "You must enter a password", "OK");
            return;
        }

        if (password.Length > 6)
        {
            await DisplayAlert("Error", "Password should be 6 characters", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Error", "The passwords do not match.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            await DisplayAlert("Error", "You must enter an email address.", "OK");
            return;
        }
        
        // if email, username, password and email are true then it will display the message "User registered successfully"
         await DisplayAlert("Success", "User registered successfully", "OK");
         await Navigation.PushAsync(new LoginPage());
        

    }
}