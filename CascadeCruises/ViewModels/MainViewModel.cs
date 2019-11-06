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
        public DelegateCommand RoomSearchCommand { get; set; }
        public DelegateCommand PassengerSearchCommand { get; set; }
        public DelegateCommand DestinationSeachCommand { get; set; }
        public DelegateCommand CruiseDurationSearchCommand { get; set; }
        public DelegateCommand CruiseSearchCommand { get; set; }
        public DelegateCommand ShipRemoveCommand { get; set; }
        public DelegateCommand PassengerRemoveCommand { get; set; }
        public DelegateCommand RoomRemoveCommand { get; set; }
        public DelegateCommand DestinationRemoveCommand { get; set; }
        public DelegateCommand CruiseDurationRemoveCommand { get; set; }
        public DelegateCommand CruiseRemoveCommand { get; set; }

        private Ship _searchedShip;
        private Room _searchedRoom;
        private Passenger _searchedPassenger;
        private Destination _searchedDestination;
        private Cruise_Duration _searchedCruiseDuration;
        private Cruise _seachedCruise;
        public Ship SearchedShip
        {
            get => _searchedShip;
            set
            {
                _searchedShip = value;
                INotifyChanged(nameof(SearchedShip));
            }
        }
        public Room SearchedRoom
        {
            get => _searchedRoom;
            set
            {
                _searchedRoom = value;
                INotifyChanged(nameof(SearchedRoom));
            }
        }
        public Passenger SearchedPassenger
        {
            get => _searchedPassenger;
            set
            {
                _searchedPassenger = value;
                INotifyChanged(nameof(SearchedPassenger));
            }
        }
        public Destination SearchedDestination
        {
            get => _searchedDestination;
            set
            {
                _searchedDestination = value;
                INotifyChanged(nameof(SearchedDestination));
            }
        }
        public Cruise_Duration SearchedCruiseDuration
        {
            get => _searchedCruiseDuration;
            set
            {
                _searchedCruiseDuration = value;
                INotifyChanged(nameof(SearchedCruiseDuration));
            }
        }
        public Cruise SearchedCruise
        {
            get => _seachedCruise;
            set
            {
                _seachedCruise = value;
                INotifyChanged(nameof(SearchedCruise));
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
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            ShipSearchCommand = new DelegateCommand(ShipSearch);
            RoomSearchCommand = new DelegateCommand(RoomSearch);
            PassengerSearchCommand = new DelegateCommand(PassengerSearch);
            DestinationSeachCommand = new DelegateCommand(DestinationSearch);
            CruiseDurationSearchCommand = new DelegateCommand(CruiseDurationSearch);
            CruiseSearchCommand = new DelegateCommand(CruiseSearch);
            ShipRemoveCommand = new DelegateCommand(ShipRemove);
            PassengerRemoveCommand = new DelegateCommand(PassengerRemove);
            RoomRemoveCommand = new DelegateCommand(RoomRemove);
            DestinationRemoveCommand = new DelegateCommand(DestinationRemove);
            CruiseDurationRemoveCommand = new DelegateCommand(CruiseDurationRemove);
            CruiseRemoveCommand = new DelegateCommand(CruiseRemove);
        }
        public void INotifyChanged(string name)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ShipSearch(object sender)
        {
            string text = (string)sender;
            if (int.TryParse(text, out int id))
            {
                SearchedShip = ShipRecords.FirstOrDefault(s => s.ID == id);
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
        public void RoomSearch(object sender)
        {
            string text = (string)sender;
            if (int.TryParse(text, out int id))
            {
                SearchedRoom = RoomRecords.FirstOrDefault(s => s.ID == id);
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
        public void PassengerSearch(object sender)
        {
            string text = (string)sender;
            if (int.TryParse(text, out int id))
            {
                SearchedPassenger = PassengerRecords.FirstOrDefault(s => s.ID == id);
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
        public void DestinationSearch(object sender)
        {
            string text = (string)sender;
            if (int.TryParse(text, out int id))
            {
                SearchedDestination = DestinationRecords.FirstOrDefault(s => s.ID == id);
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
        public void CruiseDurationSearch(object sender)
        {
            string text = (string)sender;
            if (int.TryParse(text, out int id))
            {
                SearchedCruiseDuration = Cruise_DurationRecords.FirstOrDefault(s => s.ID == id);
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
        public void CruiseSearch(object sender)
        {
            string text = (string)sender;
            if (int.TryParse(text, out int id))
            {
                SearchedCruise = CruiseRecords.FirstOrDefault(s => s.ID == id);
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }
        public void ShipRemove(object sender)
        {
            if(SearchedShip!=null)
            {
                foreach (var room in SearchedShip.Rooms)
                {
                    foreach (var passenger in room.Passengers)
                    {
                        PassengerRecords.Remove(passenger);
                    }
                    _dbContext.Passengers.RemoveRange(room.Passengers);
                    RoomRecords.Remove(room);
                }
                    _dbContext.Rooms.RemoveRange(SearchedShip.Rooms);

                foreach(var ship in SearchedShip.Cruises)
                {
                    CruiseRecords.Remove(ship);
                }
                _dbContext.Cruises.RemoveRange(SearchedShip.Cruises);
                _dbContext.Ships.Remove(SearchedShip);
                ShipRecords.Remove(SearchedShip);
                SearchedShip = null;
                _dbContext.SaveChanges();
            }
        }
        public void PassengerRemove(object sender)
        {
            if(SearchedPassenger!=null)
            {
                _dbContext.Passengers.Remove(SearchedPassenger);
                PassengerRecords.Remove(SearchedPassenger);
                SearchedPassenger = null;
                _dbContext.SaveChanges();
            }      
        }
        public void RoomRemove(object sender)
        {
            if(SearchedRoom!=null)
            {
                foreach (var passenger in SearchedRoom.Passengers)
                {
                    PassengerRecords.Remove(passenger);        
                }
                _dbContext.Passengers.RemoveRange(SearchedRoom.Passengers);
                _dbContext.Rooms.Remove(SearchedRoom);
                RoomRecords.Remove(SearchedRoom);
                SearchedRoom = null;
                _dbContext.SaveChanges();
            }
        }
        public void DestinationRemove(object sender)
        {
            if (SearchedDestination != null)
            {
                foreach(var cruise in SearchedDestination.Cruises)
                {
                    CruiseRecords.Remove(cruise);
                }
                foreach(var cruise in SearchedDestination.Cruises1)
                {
                    CruiseRecords.Remove(cruise);
                }
                _dbContext.Cruises.RemoveRange(SearchedDestination.Cruises);
                _dbContext.Cruises.RemoveRange(SearchedDestination.Cruises1);
                _dbContext.Destinations.Remove(SearchedDestination);
                DestinationRecords.Remove(SearchedDestination);
                SearchedDestination = null;
                _dbContext.SaveChanges();
            }
        }
        public void CruiseDurationRemove(object sender)
        {
            if (SearchedCruiseDuration != null)
            {
                foreach(var cruise in SearchedCruiseDuration.Cruises)
                {
                    CruiseRecords.Remove(cruise);
                }
                _dbContext.Cruises.RemoveRange(SearchedCruiseDuration.Cruises);
                _dbContext.Cruise_Duration.Remove(SearchedCruiseDuration);
                Cruise_DurationRecords.Remove(SearchedCruiseDuration);
                SearchedCruiseDuration = null;
                _dbContext.SaveChanges();
            }
        }
        public void CruiseRemove(object sender)
        {
            if (SearchedCruise != null)
            {
                _dbContext.Cruises.Remove(SearchedCruise);
                CruiseRecords.Remove(SearchedCruise);
                SearchedCruise = null;
                _dbContext.SaveChanges();
            }
        }
    }
}