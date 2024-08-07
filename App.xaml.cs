

namespace TravelBuddy
{
    public partial class App : Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();


            //// Resolve the LoginPage using the service provider
            //var loginPage = serviceProvider.GetRequiredService<LoginPage>();
            //MainPage = new NavigationPage(loginPage);
            MainPage = new AppShell();
        }
    }
}
