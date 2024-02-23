using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class RoomsViewModel : ViewModelBase
    {

        private DatabaseContext _databaseContext = new DatabaseContext();
        private readonly SelectedAccessPointStore _selectedAccessPointStore;

        private ObservableCollection<AccessPointListingItemViewModel> _accessPointListingItemViewModels;
        public AccessPointListingViewModel AccessPointListingViewModel { get; set; }

        public RoomsViewModel()
        {

            var accesspoints = _databaseContext.AccessPoints.Include(u => u.UsageHistories).ToList();
            _accessPointListingItemViewModels = new ObservableCollection<AccessPointListingItemViewModel>();
            foreach (var accesspoint in accesspoints)
            {
                _accessPointListingItemViewModels.Add(new AccessPointListingItemViewModel(accesspoint));
            }
        }


    }
}
