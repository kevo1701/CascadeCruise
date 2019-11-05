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

        public MainViewModel()
        {
            _dbContext = new Cascade_CruisesEntities();
            ShipRecords = new ObservableCollection<Ship>(_dbContext.Ships);
            CruiseRecords = new ObservableCollection<Cruise>(_dbContext.Cruises);
        }  
    }
}