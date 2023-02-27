using CommunityToolkit.Maui.Views;

namespace Lecturer;

public partial class schedulepageothers : Popup
{
	public schedulepageothers()
	{
		InitializeComponent();
	}
    private void Closeothersclicked(object sender, EventArgs e)
    {
        this.Close();
    }
    private void Submitothersclicked(object sender, EventArgs e)
    {
       /* var popup = new schedulesuccess();
        this.ShowPopup(popup);*/
    }
}