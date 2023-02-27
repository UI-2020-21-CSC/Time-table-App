using CommunityToolkit.Maui.Views;

namespace Lecturer;

public partial class MainPage : ContentPage
{
	int count = 0;
	
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

	    private void OnCounterClicked(object sender, EventArgs e)
	{/*
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);*/
	}
}

