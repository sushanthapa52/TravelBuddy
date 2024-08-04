using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TravelBuddy.Login
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        private DateTime _tripDate = DateTime.Today;
        private int _selectedActivityIndex;

        public string TripName { get; set; }

        public DateTime TripDate
        {
            get => _tripDate;
            set
            {
                _tripDate = value;
                OnPropertyChanged();
            }
        }

        public int SelectedActivityIndex
        {
            get => _selectedActivityIndex;
            set
            {
                _selectedActivityIndex = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
