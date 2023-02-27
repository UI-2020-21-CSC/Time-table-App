namespace Time_table.Admin_Page.View;

public partial class AdminHomePage : ContentPage
{
	public AdminHomePage(AdminHomePageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}