using TravelBuddy.ViewModel;
namespace TravelBuddy.Views;


public partial class HomePage : ContentPage
{
	private HomePageViewModel _homePageViewModel;
	public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
        _homePageViewModel = homePageViewModel;
		BindingContext = _homePageViewModel;
    }
}