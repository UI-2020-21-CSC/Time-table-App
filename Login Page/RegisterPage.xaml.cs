using System.Xml.Linq;

namespace Time_table;

public partial class RegisterPage : ContentPage
{
    UserRepo userRepository = new();
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        try
        {
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;
            string email = EmailEntry.Text;

            if (String.IsNullOrEmpty(username))
            {
                await DisplayAlert("Warning", "Type name", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(email))
            {
                await DisplayAlert("Warning", "Type email", "Ok");
                return;
            }
            if (password.Length < 6)
            {
                await DisplayAlert("Warning", "Password should be 6 digit.", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(password))
            {
                await DisplayAlert("Warning", "Type password", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(confirmPassword))
            {
                await DisplayAlert("Warning", "Type Confirm password", "Ok");
                return;
            }
            if (password != confirmPassword)
            {
                await DisplayAlert("Warning", "Password not match.", "Ok");
                return;
            }
            if (!(email.Contains('@')))
            {
                await DisplayAlert("Error", "Email must include @", "OK");
                return;
            }

            bool isSave = await userRepository.Register(email, password);
            if (isSave)
            {
                await DisplayAlert("Register user", "Registration completed", "Ok");
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Register user", "Registration failed", "Ok");
            }
        }
        catch (Exception exception)
        {
            if (exception.Message.Contains("EMAIL_EXISTS"))
            {
                await DisplayAlert("Warning", "Email exist", "Ok");
            }
            else
            {
                await DisplayAlert("Error", exception.Message, "Ok");
            }

        }


    }
}


