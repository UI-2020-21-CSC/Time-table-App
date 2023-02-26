using CommunityToolkit.Maui.Views;

namespace Lecturer;

public partial class logout : Popup
{
	public logout()
	{
		InitializeComponent();
	}
	private void CLoselogout(object sender, EventArgs e)
	{
		this.Close();
	}
	private void Noclicked(object sender, EventArgs e)
	{
		this.Close();
	}
}