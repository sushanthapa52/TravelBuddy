namespace TravelBuddy.Login;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        BindingContext = new HomePageViewModel();
    }
}