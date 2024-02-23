using Microsoft.EntityFrameworkCore;
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

            var rooms = _databaseContext.AccessPoints.Include(u => u.UsageHistories).ThenInclude(u => u.User)
                .Where(u => u.Id == accessPoint.Id && u.UsageHistories.Any(u => u.User.IsInRoom == true)).Count();
                

            UsersCount = rooms;
            
        }
    }
}
