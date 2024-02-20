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

        private DatabaseContext _databaseContext = new DatabaseContext();


        public AccessPointListingViewModel()
        {

            var accesspoints = _databaseContext.AccessPoints.ToList();
            _accessPointListingItemViewModels = new ObservableCollection<AccessPointListingItemViewModel>();
            foreach (var accesspoint in accesspoints)
            {
                _accessPointListingItemViewModels.Add(new AccessPointListingItemViewModel(accesspoint));
            }
        }
    }
}
