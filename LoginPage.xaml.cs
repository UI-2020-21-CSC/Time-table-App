namespace Time_table;

public partial class LoginPage : ContentPage
{ 
    public LoginPage()
    {
        InitializeComponent();
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        if (email == "admin" && password == "admin")
        {
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            DisplayAlert("Error", "Invalid username or password", "OK");
        }

            // SemanticScreenReader.Announce(CounterBtn.Text);
        
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegisterPage());
    }
}
