using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CascadeCruises.ViewModels
{
   public class MainViewModel
    {
        private Cascade_CruisesEntities _dbContext;
        public ObservableCollection<Ship> ShipRecords { get; set; }
        public ObservableCollection<Cruise> CruiseRecords { get; set; }
        public ObservableCollection<Room> RoomRecords { get; set; }
        public ObservableCollection<Passenger> PassengerRecords { get; set; }
        public ObservableCollection<Destination> DestinationRecords { get; set; }
        public ObservableCollection<Cruise_Duration> Cruise_DurationRecords { get; set; }
        public MainViewModel()
        {
            _dbContext = new Cascade_CruisesEntities();
            ShipRecords = new ObservableCollection<Ship>(_dbContext.Ships);
            CruiseRecords = new ObservableCollection<Cruise>(_dbContext.Cruises);
            RoomRecords = new ObservableCollection<Room>(_dbContext.Rooms);
            PassengerRecords = new ObservableCollection<Passenger>(_dbContext.Passengers);
            DestinationRecords = new ObservableCollection<Destination>(_dbContext.Destinations);
            Cruise_DurationRecords = new ObservableCollection<Cruise_Duration>(_dbContext.Cruise_Duration);
        }  
    }
}