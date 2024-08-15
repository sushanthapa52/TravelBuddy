using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelBuddy.Entities;
using TravelBuddy.Service;

namespace TravelBuddy.ViewModel
{
    public class ChecklistViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly FirestoreService _firestoreService;

        private string _token;
        private string _tripName;
        private string _tripDate;
        private string _activityType;

        public ChecklistViewModel()
        {

        }
        public ChecklistViewModel(FirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
            SaveCommand = new Command(OnSaveClicked);
            SignOutCommand = new Command(OnSignOutClicked);

            //OnLoadItems("Hiking");
        }

        public ObservableCollection<ChecklistItem> Items { get; } = new ObservableCollection<ChecklistItem>();

        public ICommand SaveCommand { get; }
        public ICommand SignOutCommand { get; }

        public ICommand LoadItemsCommand { get; }

        public string TripName
        {
            get => _tripName;
            set => SetProperty(ref _tripName, value);
        }

        public string TripDate
        {
            get => _tripDate;
            set => SetProperty(ref _tripDate, value);
        }

        public string ActivityType
        {
            get => _activityType;
            set => SetProperty(ref _activityType, value);
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("userId"))
            {
                _token = query["userId"] as string;
            }

            if (query.ContainsKey("tripName"))
            {
                TripName = Uri.UnescapeDataString(query["tripName"] as string);
            }

            if (query.ContainsKey("activityType"))
            {
                ActivityType = Uri.UnescapeDataString(query["activityType"] as string) ?? string.Empty;
            }

            if (query.ContainsKey("tripDate"))
            {
                var encodedDate = query["tripDate"] as string;

                // Decode the URL-encoded string
                var decodedDate = Uri.UnescapeDataString(encodedDate);

                // Parse the date and extract only the date portion
                if (DateTime.TryParse(decodedDate, out DateTime parsedDate))
                {
                    TripDate = parsedDate.ToString("M/d/yyyy"); // Format as "8/11/2024"
                }

            }

            if (query.ContainsKey("checklist"))
            {
                var checklist = query["checklist"] as List<string>; // Assuming the checklist is passed as a List<string>

                // You can now process the checklist as needed, e.g., assign it to a property:
            }

            // Call OnLoadItems after query parameters are processed
            if (!string.IsNullOrEmpty(ActivityType))
            {
                OnLoadItems(ActivityType);
            }
        }

        private void OnLoadItems(string activityType)
        {
            Items.Clear();


            switch (activityType)
            {
                case "Hiking":
                    var hiking = new Hiking();
                    foreach (var item in hiking.Items)
                    {
                        Items.Add(new ChecklistItem { Name = item, IsSelected = false });
                    }
                    break;

                case "Camping":
                    var camping = new Camping();
                    foreach (var item in camping.Items)
                    {
                        Items.Add(new ChecklistItem { Name = item, IsSelected = false });
                    }
                    break;

                case "Beach":
                    var beach = new Beach();
                    foreach (var item in beach.Items)
                    {
                        Items.Add(new ChecklistItem { Name = item, IsSelected = false });
                    }
                    break;

                case "Skiing":
                    var skiing = new Skiing();
                    foreach (var item in skiing.Items)
                    {
                        Items.Add(new ChecklistItem { Name = item, IsSelected = false });
                    }
                    break;

                case "Road_Trip":
                    var roadTrip = new RoadTrip();
                    foreach (var item in roadTrip.Items)
                    {
                        Items.Add(new ChecklistItem { Name = item, IsSelected = false });
                    }
                    break;

                case "Cycling":
                    var cycling = new Cycling();
                    foreach (var item in cycling.Items)
                    {
                        Items.Add(new ChecklistItem { Name = item, IsSelected = false });
                    }
                    break;

                default:
                    // Optionally handle an unknown activity type
                    break;
            }
        }

        private async void OnSaveClicked()
        {
            var selectedItems = Items.Where(item => item.IsSelected).Select(item => item.Name).ToList();

            // Save the selected items to Firebase Realtime Database
            var userId = _token; // Replace with the actual user ID
            await _firestoreService.SaveSelectedItemsAsync(userId, selectedItems);

            await Application.Current.MainPage.DisplayAlert("Success", "Checklist saved successfully!", "OK");
        }
        private async void OnSignOutClicked()
        {
            // Perform any necessary sign out logic here
            // Navigate to the login page
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }

    public class ChecklistItem : ObservableObject
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }


}
