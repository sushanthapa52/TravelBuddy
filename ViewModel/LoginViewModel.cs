using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.Service;
using TravelBuddy.Views;

namespace TravelBuddy.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        private string _email;
        private string _password;
        private string _loginResult;
        private readonly FirestoreService _firestoreService;
        private readonly FirebaseAuthentication _authService;


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

             await Shell.Current.GoToAsync($"///{nameof(HomePage)}?token={token}");
                    
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
