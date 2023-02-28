using Time_table.Admin_Page;

namespace Time_table;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		
        Routing.RegisterRoute(nameof(AdminHomePage), typeof(AdminHomePage));
        Routing.RegisterRoute("VenueListPage", typeof(VenueListPage));
	}
}
