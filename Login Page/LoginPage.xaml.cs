using Time_table.Admin_Page;
using Time_table.Student_Page;

namespace Time_table;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private UserRepo userRepository = new();
    private async void Button_Clicked(object sender, EventArgs e)
    {

        try
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            string token = await userRepository.SignIn(email, password);

            if (String.IsNullOrEmpty(email))
            {
                await DisplayAlert("Error", "You must enter an email.", "OK");
                return;
            }

            if (String.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "You must enter a password", "OK");
                return;
            }
            if (!(email.Contains('@')))
            {
                await DisplayAlert("Error", "Email must include @", "OK");
                return;
            }
            if (!string.IsNullOrEmpty(token))
            {
                if (txtEmail.Text == "admin@user.com" && txtPassword.Text == "123456")
                {
                    await Navigation.PushAsync(new AdminHomePage());
                }
                else
                {
                    await Navigation.PushAsync(new StuHomePage());
                }

            }

        }
        catch (Exception exception)
        {
            if (exception.Message.Contains("InvalidEmailAddress") || exception.Message.Contains("UnknownEmailAddress"))
            {
                await DisplayAlert("Error", "Email not found", "Ok");
            }
            else if (exception.Message.Contains("MissingPassword") || exception.Message.Contains("WrongPassword"))
            {
                await DisplayAlert("Error", "Password not found", "Ok");
            }
            else if (exception.Message.Contains("Undefined"))
            {
                await DisplayAlert("Error", "Internet Connection Required", "Ok");
            }
            else
            {
                await DisplayAlert("Error", exception.Message, "Ok");
            }
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

