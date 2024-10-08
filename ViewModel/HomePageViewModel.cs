﻿using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelBuddy.Service;


namespace TravelBuddy.ViewModel
{
    public class HomePageViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly FirestoreService _firestoreService;
        private string _token;

        public HomePageViewModel(FirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
            SaveCommand = new Command(OnSaveClicked);
            ResetCommand = new Command(OnResetClicked);
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("token"))
            {
                 _token = query["token"] as string;

            }
        }
        private string _tripName;
        public string TripName
        {
            get => _tripName;
            set => SetProperty(ref _tripName, value);
        }

        private DateTime _tripDate = DateTime.Now;
        public DateTime TripDate
        {
            get => _tripDate;
            set => SetProperty(ref _tripDate, value);
        }

        private int _selectedActivityIndex;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int SelectedActivityIndex
        {
            get => _selectedActivityIndex;
            set => SetProperty(ref _selectedActivityIndex, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand ResetCommand { get; }

        private async void OnSaveClicked()
        {
            var activity = GetSelectedActivity();
            if (string.IsNullOrEmpty(TripName) || string.IsNullOrEmpty(activity))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please enter all details.", "OK");
                return;
            }

            var userId = _token; // Replace with the actual Firebase user ID

            var tripDetails = new UserActivity
            {
                ActivityType = activity,
                ActivityDate = TripDate,
                TripName = TripName
            };

            try
            {
                await _firestoreService.SaveUserActivityAsync(userId, tripDetails);
                await Application.Current.MainPage.DisplayAlert("Success", "Trip details saved successfully!", "OK");
                // redirect into new page listing all the details
                var userActivityDetails = await _firestoreService.GetUserActivityAsync(userId);
                await Shell.Current.GoToAsync($"///ChecklistPage?userId={userId}&tripName={TripName}&tripDate={userActivityDetails.ActivityDate.ToString()}&activityType={activity}");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to save trip details: {ex.Message}", "OK");
            }
        }

        private void OnResetClicked()
        {
            TripName = string.Empty;
            TripDate = DateTime.Now;
            SelectedActivityIndex = -1;
        }

        private string GetSelectedActivity()
        {
            switch (SelectedActivityIndex)
            {
                case 0:
                    return "Hiking";
                case 1:
                    return "Camping";
                case 2:
                    return "Beach";
                case 3:
                    return "Skiing";
                case 4:
                    return "Road Trip";
                case 5:
                    return "Cycling";
                default:
                    return null;
            }
        }
    }
}
