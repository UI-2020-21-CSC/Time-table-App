using CommunityToolkit.Maui.Views;

namespace Lecturer;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	private void LogoutClick(object sender,EventArgs e)
	{
		outlog.IsVisible = true;
    }
	private void MYactivelogoutclicked(object sender, EventArgs e)
	{
        var popup = new logout();
        this.ShowPopup(popup);
    }
    private void CancClick(object sender, EventArgs e)
	{   
		CClass.IsVisible = true;	
    }
}

