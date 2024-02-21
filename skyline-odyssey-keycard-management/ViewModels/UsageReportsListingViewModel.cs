using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class UsageReportsListingViewModel : ViewModelBase
    {

        private ObservableCollection<UsageReportsListingItemViewModel> _usageReportsListingItemViewModels;

        public IEnumerable<UsageReportsListingItemViewModel> UsageReportsListingItemViewModels => _usageReportsListingItemViewModels;

        private DatabaseContext _databaseContext = new DatabaseContext();

        public UsageReportsListingViewModel()
        {
            var usagereports = _databaseContext.UsageHistories.Include(u => u.AccessPoint).Include(u => u.Keycard).ToList();
            _usageReportsListingItemViewModels = new ObservableCollection<UsageReportsListingItemViewModel>();
            foreach (var usagereport in usagereports)
            {
                _usageReportsListingItemViewModels.Add(new UsageReportsListingItemViewModel(usagereport));

            }
            

        }
    }
}
