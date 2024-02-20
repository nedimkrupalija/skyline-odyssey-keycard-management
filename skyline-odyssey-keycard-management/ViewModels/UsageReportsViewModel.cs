using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class UsageReportsViewModel : ViewModelBase
    {
        public UsageReportsListingViewModel UsageReportsListingViewModel { get; set; }

        public UsageReportsViewModel()
        {
            UsageReportsListingViewModel = new UsageReportsListingViewModel();
        }
    }
}
