using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class AccessPointViewModel
    {
        public AccessPointDetailsViewModel AccessPointDetailsViewModel { get; set; }
        public AccessPointListingViewModel AccessPointListingViewModel { get; set; }

        public AccessPointViewModel()
        {
            AccessPointDetailsViewModel = new AccessPointDetailsViewModel();
            AccessPointListingViewModel = new AccessPointListingViewModel();
        }
    }
}
