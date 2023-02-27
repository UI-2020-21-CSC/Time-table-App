namespace Time_table;

public partial class PasswordPage : ContentPage
{
    UserRepo _userRepository = new();
    public PasswordPage()
	{
		InitializeComponent();
	}

    private async void ButtonSendLink_Clicked(object sender, EventArgs e)
    {
        try
        {
            string email = textEmail.Text;
            if (string.IsNullOrEmpty(email))
            {
                await DisplayAlert("Warning", "Please enter your email.", "Ok");
                return;
            }

            bool isSend = await _userRepository.ResetPassword(email);
            if (isSend)
            {
                await DisplayAlert("Reset Password", "Link has been sent to your email", "Ok");
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Reset Password", "Link send failed.", "Ok");
            }
        }
        catch (Exception exception)
        {
            if (exception.Message.Contains("InvalidEmailAddress") || exception.Message.Contains("UnknownEmailAddress"))
            {
                await DisplayAlert("Error", "Email not found", "Ok");
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
}