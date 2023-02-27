using CommunityToolkit.Maui.Views;

namespace Lecturer;

public partial class addcourse : ContentPage
{
	public addcourse()
	{
		InitializeComponent();
	}
	private void Dropdownclicked (object sender, EventArgs e)
	{
        var popup = new addcoursedropdown();
        this.ShowPopup(popup);
    }
}