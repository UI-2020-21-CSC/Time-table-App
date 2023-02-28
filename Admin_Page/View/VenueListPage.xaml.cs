
using Time_table.Admin_Page.ViewModel;

namespace Time_table.Admin_Page;

public partial class VenueListPage : ContentPage
{


    public VenueListPage(VenueListPageViewModel viewModel)
	{
		InitializeComponent();

		this.BindingContext = viewModel;
	}
}