using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class AccessPointListingItemViewModel : ViewModelBase
    {

        public AccessPoint AccessPoint { get; set; }

        public string Name => AccessPoint.Name;

        public int AccessLevel => AccessPoint.AccessLevel;


        public AccessPointListingItemViewModel(AccessPoint accessPoint)
        {
            AccessPoint = accessPoint;
        }
    }
}
