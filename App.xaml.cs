using Time_table.Admin_Page;

namespace Time_table;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new LoginPage());


	}
}
