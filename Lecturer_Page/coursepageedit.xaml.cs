using CommunityToolkit.Maui.Views;

namespace Lecturer;

public partial class coursepageedit : Popup
{
	public coursepageedit()
	{
		InitializeComponent();
	}
	private void CLoseme(object sender, EventArgs e)
	{
		this.Close();
	}
}