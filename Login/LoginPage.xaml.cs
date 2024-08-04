using System.ComponentModel;

namespace TravelBuddy.Login;

public partial class LoginPage : ContentPage
{
    private LoginViewModel _viewModel;

    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var email = emailEntry.Text;
        var password = passwordEntry.Text;
        await _viewModel.Login(email, password);
    }
}