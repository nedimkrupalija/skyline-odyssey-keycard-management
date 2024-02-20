using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class EmployeeListingItemViewModel  : ViewModelBase
    {
        public User User { get; set; }

        public string FirstName => User.FirstName;

        public string LastName => User.LastName;

        public EmployeeListingItemViewModel(User user)
        {
            User = user;
        }
    }
}
