using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class AccessPointListingViewModel : ViewModelBase
    {
        private ObservableCollection<AccessPointListingItemViewModel> _accessPointListingItemViewModels;

        public IEnumerable<AccessPointListingItemViewModel> AccessPointListingItemViewModels => _accessPointListingItemViewModels;


        public AccessPointListingViewModel()
        {
            _accessPointListingItemViewModels = new ObservableCollection<AccessPointListingItemViewModel>
            {
                new AccessPointListingItemViewModel(new AccessPoint(1, 2, "room1")),
                new AccessPointListingItemViewModel(new AccessPoint(1, 2, "room2")),
                new AccessPointListingItemViewModel(new AccessPoint(1, 2, "room3")),
            };
        }
    }
}
