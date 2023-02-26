using CommunityToolkit.Maui.Views;

namespace Lecturer;

public partial class schedulepagecancel : ContentPage
{
	public schedulepagecancel()
	{
		InitializeComponent();
	}
	
	private void Othersoptionclicked(object sender, EventArgs e)
	{
			var popup = new schedulepageothers();
			this.ShowPopup(popup);
	}

	

}