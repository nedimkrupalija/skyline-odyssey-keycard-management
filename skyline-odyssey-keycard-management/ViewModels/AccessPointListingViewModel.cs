using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Store;
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
        private readonly SelectedAccessPointStore _selectedAccessPointStore;
        private ObservableCollection<AccessPointListingItemViewModel> _accessPointListingItemViewModels;

        public IEnumerable<AccessPointListingItemViewModel> AccessPointListingItemViewModels => _accessPointListingItemViewModels;

        private DatabaseContext _databaseContext = new DatabaseContext();

	    public static AccessPoint CurrentAccessPoint { get; set; }

		private AccessPointListingItemViewModel _selectedAccessPointListingItemViewModel;
        public AccessPointListingItemViewModel SelectedAccessPointListingItemViewModel
        {

            get
            {
                return _selectedAccessPointListingItemViewModel;
            }
            set
            {
                _selectedAccessPointListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedAccessPointListingItemViewModel));
                CurrentAccessPoint = _selectedAccessPointListingItemViewModel.AccessPoint;
                OnPropertyChanged(nameof(CurrentAccessPoint));
                _selectedAccessPointStore.SelectedAccessPoint = _selectedAccessPointListingItemViewModel?.AccessPoint;
            }
        }

        

        public AccessPointListingViewModel(SelectedAccessPointStore selectedAccessPointStore)
        {
            _selectedAccessPointStore = selectedAccessPointStore;

            var accesspoints = _databaseContext.AccessPoints.Include(u=>u.UsageHistories).ThenInclude(u=>u.User).ToList();
            _accessPointListingItemViewModels = new ObservableCollection<AccessPointListingItemViewModel>();
            foreach (var accesspoint in accesspoints)
            {
                _accessPointListingItemViewModels.Add(new AccessPointListingItemViewModel(accesspoint));
            }
        }
    }
}
