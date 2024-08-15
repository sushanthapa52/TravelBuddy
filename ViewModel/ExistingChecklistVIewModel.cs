using Google.Cloud.Firestore.V1;
using Microsoft.VisualBasic;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelBuddy.Entities;
using TravelBuddy.Service;

namespace TravelBuddy.ViewModel
{
    public class ExistingChecklistVIewModel: BaseViewModel, INotifyPropertyChanged, IQueryAttributable
    {
        private readonly FirestoreService _firestoreService;
        private string _userId;
        private ExistingChecklistVIewModel _viewModel;
        public string TripName;
        public DateTime TripDate;
        public string ActivityType;
        private string _token;


        public ObservableCollection<ChecklistItem> SelectedActivityChecklist { get; set; }

        public ExistingChecklistVIewModel() { }
        public ExistingChecklistVIewModel(FirestoreService firestoreService)
        {
            _firestoreService = firestoreService;


            // Call the LoadChecklistAsync method
            SelectedActivityChecklist = new ObservableCollection<ChecklistItem>();

            SaveChecklistCommand = new Command(async () => await SaveChecklistAsync());

            SignOutCommand = new Command(OnSignOutClicked);


        }
        public ICommand SignOutCommand { get; }
        public ICommand SaveChecklistCommand { get; }


        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("userId"))
            {
                _token = query["userId"] as string;
            }

            if (query.ContainsKey("tripName"))
            {
                TripName = query["tripName"] as string;
            }

            if (query.ContainsKey("activityType"))
            {
                ActivityType = query["activityType"] as string ?? string.Empty;
            }

            if (query.ContainsKey("tripDate") && DateTime.TryParse(query["tripDate"] as string, out DateTime parsedDate))
            {
                TripDate = parsedDate;
            }

            if (!string.IsNullOrEmpty(_token))
            {
                LoadChecklistAsync(_token, ActivityType);
            }

        }
        public async Task LoadChecklistAsync(string userId, string activityType)
        {
            _userId = userId;

            // Retrieve the user's selected items from Firestore
            var selectedItems = await _firestoreService.GetUserChecklistAsync(userId);

            // Clear the existing items in the collection
            SelectedActivityChecklist.Clear();

            // Load all possible items for the activity
            List<string> allItems = GetAllItemsForActivity(activityType);

            // Add all items to the checklist, marking those that are selected
            foreach (var item in allItems)
            {
                SelectedActivityChecklist.Add(new ChecklistItem
                {
                    Name = item,
                    IsSelected = selectedItems.Contains(item) // Mark as selected if it's in the user's checklist
                });
            }
        }

        private List<string> GetAllItemsForActivity(string activityType)
        {
            switch (activityType)
            {
                case "Hiking":
                    return new Hiking().Items;
                case "Camping":
                    return new Camping().Items;
                case "Beach":
                    return new Beach().Items;
                case "Skiing":
                    return new Skiing().Items;
                case "Road Trip":
                    return new RoadTrip().Items;
                case "Cycling":
                    return new Cycling().Items;
                default:
                    return new List<string>(); // Return an empty list if the activity type is unknown
            }
        }
        private async void OnSignOutClicked()
        {
            // Perform any necessary sign out logic here
            // Navigate to the login page
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async Task SaveChecklistAsync()
        {
            var updatedChecklist = SelectedActivityChecklist
                .Where(item => item.IsSelected)
                .Select(c => c.Name)
                .ToList();

            await _firestoreService.SaveSelectedItemsAsync(_userId, updatedChecklist);
        }
    }
}
