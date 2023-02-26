using CommunityToolkit.Maui.Views;

namespace Lecturer;

public partial class coursepage : ContentPage
{
	public coursepage()
	{
		InitializeComponent();
	}
	private void Myeditclicked(object sender, EventArgs e)
	{
        var popup = new coursepageedit();
        this.ShowPopup(popup);

    }
	private void Mydeleteclicked(object sender, EventArgs e)
	{
			// editdelete.IsVisible = false;

    }
	private void Showeditdeleteclicked(object sender, EventArgs e)
	{
		editdelete.IsVisible = true;
	}
}