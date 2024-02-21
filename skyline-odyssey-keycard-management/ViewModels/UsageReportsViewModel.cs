using skyline_odyssey_keycard_management.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class UsageReportsViewModel : ViewModelBase
    {

        private ObservableCollection<UsageReportsListingItemViewModel> _usageReportsListingItemViews;

        public IEnumerable<UsageReportsListingItemViewModel> UsageReportsListingItemViewModels => _usageReportsListingItemViews;

        private DatabaseContext _databaseContext = new DatabaseContext();

        private UsageReportsListingItemViewModel _selectedAccessPointListingItemViewModel;

        public UsageReportsListingItemViewModel SelectedAccessPointListingItemViewModel
        {

            get
            {
                return _selectedAccessPointListingItemViewModel;
            }
            set
            {
                _selectedAccessPointListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedAccessPointListingItemViewModel));
            }
        }
        public UsageReportsListingViewModel UsageReportsListingViewModel { get; set; }

        public UsageReportsViewModel()
        {
            UsageReportsListingViewModel = new UsageReportsListingViewModel();
        }
    }
}
