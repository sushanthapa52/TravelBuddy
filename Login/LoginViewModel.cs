using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Login
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly FirebaseAuthentication _authService;

        private string _email;
        private string _password;
        private string _loginResult;
        private readonly INavigation _navigation;

        public LoginViewModel(FirebaseAuthentication authService)
        {
            _authService = authService;

        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string LoginResult
        {
            get => _loginResult;
            set
            {
                _loginResult = value;
                OnPropertyChanged();
            }
        }

        public async Task Login(string Email, string Password)
        {
            var token = await _authService.LoginWithEmailPassword(Email, Password);
            if (token != null)
            {
                LoginResult = "Login successful";
                // Navigate to HomePage using Shell
                await Shell.Current.GoToAsync("home");

            }
            else
            {
                LoginResult = "Login failed";
                // Handle login failure
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
