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

        private DatabaseContext _databaseContext;

        public AccessPoint AccessPoint { get; set; }

        public string Name => AccessPoint.Name;

        public int AccessLevel => AccessPoint.AccessLevel;

        public int UsersCount { get; set;}

        public AccessPointListingItemViewModel(AccessPoint accessPoint)
        {
            _databaseContext = new DatabaseContext();
            AccessPoint = accessPoint;
            UsersCount = _databaseContext.Users.Where(u => u.IsInRoom == true).Count();
            
        }
    }
}
