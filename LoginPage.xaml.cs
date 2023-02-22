namespace Time_table;

public partial class LoginPage : ContentPage
{ 
    public LoginPage()
    {
        InitializeComponent();
    }
    //create a function to check the database for the user and password, if both are correct then check their roles and navigate to the correct page

    private void OnLoginClicked(object sender, EventArgs e)
    {
        string email = txtEmail.Text;
        string password = txtPassword.Text;

        // sample code will change the inside if statement to become if (role == "admin") then navigate to the admin page, if (role == "lecturer") then navigate to the lecturer page, if (role == "student") then navigate to the student page.

        if (email == "admin" && password == "admin")
        {
            // Display login success message thenn navigate to the admin page
            DisplayAlert("Success", "Login successful", "OK");
            Navigation.PushAsync(new Admin_Page.AdminHomePage());
        }
        else if (email == "lecturer" && password == "lecturer")
        {
            // Display login success message thenn navigate to the lecturer page
            DisplayAlert("Success", "Login successful", "OK");
            Navigation.PushAsync(new Lecturer_Page.HomePage());
        }
        else if (email == "student" && password == "student")
        {
            // Display login success message thenn navigate to the student page
            DisplayAlert("Success", "Login successful", "OK");
            Navigation.PushAsync(new Student_Page.StuHomePage());
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
