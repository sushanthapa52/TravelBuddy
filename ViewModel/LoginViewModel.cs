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


        public LoginViewModel(FirebaseAuthentication authService, FirestoreService firestoreService)
        {
            _authService = authService;
            _firestoreService = firestoreService;
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


            // Check if the user has a checklist in the database
            var userChecklist = await _firestoreService.GetUserChecklistAsync(token);

            if (userChecklist != null)
            {
                // Redirect to the ChecklistPage with the checklist data
                //var navigationParameters = new Dictionary<string, object>
                //{
                //    { "token", token },
                //    { "checklist", userChecklist }
                //};
               // await Shell.Current.GoToAsync($"///{nameof(ExistingChecklistPage)}", navigationParameters);
                await Shell.Current.GoToAsync($"///{nameof(ExistingChecklistPage)}");


            }
            else
            {
                await Shell.Current.GoToAsync($"///{nameof(HomePage)}?token={token}");

            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
