using Google.Cloud.Firestore.V1;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using TravelBuddy.Service;

namespace TravelBuddy.ViewModel
{
    public class ExistingChecklistVIewModel: BaseViewModel, INotifyPropertyChanged
    {
        private readonly FirestoreService _firestoreService;
        private string _userId;
        private ExistingChecklistVIewModel _viewModel;


        public ObservableCollection<ChecklistItem> SelectedActivityChecklist { get; set; }

        public ExistingChecklistVIewModel() { }
        public ExistingChecklistVIewModel(FirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
            LoadChecklistAsync("qpHwEijpbhe8zqYX1OxrdRRF03F2"); // Pass the actual userId here


            // Call the LoadChecklistAsync method
            SelectedActivityChecklist = new ObservableCollection<ChecklistItem>();
        }

        public async Task LoadChecklistAsync(string userId)
        {
            _userId = userId;

            var checklist = await _firestoreService.GetUserChecklistAsync(userId);

            SelectedActivityChecklist.Clear();

            foreach (var item in checklist)
            {
                SelectedActivityChecklist.Add(new ChecklistItem
                {
                    Name = item,
                    IsSelected = false // Initialize as unchecked
                });
            }
        }

        // Call this method to save the updated checklist back to Firebase
        //public async Task SaveChecklistAsync()
        //{
        //    var updatedChecklist = SelectedActivityChecklist.Select(c => c.Name).ToList();
        //    await _firestoreService.SaveUserChecklistAsync(_userId, updatedChecklist);
        //}
    }
}
