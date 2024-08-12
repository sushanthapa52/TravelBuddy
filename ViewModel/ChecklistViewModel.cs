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

        public string TripName;
        public DateTime TripDate;
        public string Category;

        public ChecklistViewModel()
        {

        }
        public ChecklistViewModel(FirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
            SaveCommand = new Command(OnSaveClicked);
            OnLoadItems("Hiking");
        }

        public ObservableCollection<ChecklistItem> Items { get; } = new ObservableCollection<ChecklistItem>();

        public ICommand SaveCommand { get; }
        public ICommand LoadItemsCommand { get; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("userId"))
            {
                _token = query["userId"] as string;
                TripName = query["tripName"] as string;
                Category = query["activityType"] as string ?? string.Empty;
                if (DateTime.TryParse(query["tripDate"] as string, out DateTime parsedDate))
                {
                    TripDate = parsedDate;
                }


            }
        }
        private void OnLoadItems(string activityType)
        {
            Items.Clear();

            if (activityType == "Hiking")
            {
                var hiking = new Hiking();
                foreach (var item in hiking.Items)
                {
                    Items.Add(new ChecklistItem { Name = item, IsSelected = false });
                }
            }
            // Add logic for other activities
        }

        private async void OnSaveClicked()
        {
            var selectedItems = Items.Where(item => item.IsSelected).Select(item => item.Name).ToList();

            // Save the selected items to Firebase Realtime Database
            var userId = _token; // Replace with the actual user ID
            await _firestoreService.SaveSelectedItemsAsync(userId, selectedItems);

            await Application.Current.MainPage.DisplayAlert("Success", "Checklist saved successfully!", "OK");
        }
    }

    public class ChecklistItem : ObservableObject
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }


}
