﻿using Microsoft.VisualBasic;
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

        private string TripName;
        private string ActivityType;
        private string TripDate;

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
            //var tripName = await _firestoreService.GetTripNameAsync(token);

            var userActivity = await _firestoreService.GetUserActivityAsync(token);
            if (userActivity == null && token is not null) {
                await Shell.Current.GoToAsync($"///{nameof(HomePage)}?token={token}");

            }


            if (userActivity != null)
            {
                var userChecklist = await _firestoreService.GetUserChecklistAsync(token);

                if (userChecklist != null)
                {
                    TripName = userActivity.TripName;
                    ActivityType = userActivity.ActivityType;
                    TripDate = userActivity.ActivityDate.ToString();

                    await Shell.Current.GoToAsync($"///{nameof(ExistingChecklistPage)}?userId={token}&activityType={ActivityType}&tripName={TripName}&tripDate={TripDate}");


                    // Load the checklist based on the activity type
                }
                await Shell.Current.GoToAsync($"///{nameof(HomePage)}?token={token}");


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
