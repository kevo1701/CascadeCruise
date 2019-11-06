using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CascadeCruises.ViewModels
{
   public class MainViewModel : INotifyPropertyChanged
    {
        private Cascade_CruisesEntities _dbContext;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Ship> ShipRecords { get; set; }
        public ObservableCollection<Cruise> CruiseRecords { get; set; }
        public ObservableCollection<Room> RoomRecords { get; set; }
        public ObservableCollection<Passenger> PassengerRecords { get; set; }
        public ObservableCollection<Destination> DestinationRecords { get; set; }
        public ObservableCollection<Cruise_Duration> Cruise_DurationRecords { get; set; }
        public DelegateCommand ShipSearchCommand { get; set; }
        private Ship _searchedShip;
        public Ship SearchedShip 
        {
            get =>  _searchedShip;
            set
            {
                _searchedShip = value;
                INotifyChanged(nameof(SearchedShip));
            } 
        }

        public MainViewModel()
        {
            _dbContext = new Cascade_CruisesEntities();
            ShipRecords = new ObservableCollection<Ship>(_dbContext.Ships);
            CruiseRecords = new ObservableCollection<Cruise>(_dbContext.Cruises);
            RoomRecords = new ObservableCollection<Room>(_dbContext.Rooms);
            PassengerRecords = new ObservableCollection<Passenger>(_dbContext.Passengers);
            DestinationRecords = new ObservableCollection<Destination>(_dbContext.Destinations);
            Cruise_DurationRecords = new ObservableCollection<Cruise_Duration>(_dbContext.Cruise_Duration);
            ShipSearchCommand = new DelegateCommand(ShipSearch);
        }  
        public void INotifyChanged (string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ShipSearch(object sender)
        {
            string text = (string)sender;
            if(int.TryParse(text,out int id))
            {
                SearchedShip = ShipRecords.FirstOrDefault(s => s.ID == id);
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
    }
}