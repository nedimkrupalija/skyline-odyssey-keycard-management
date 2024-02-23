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


        private User _user;

        public User User
        {
			get { return _user; }
			set
            {
				_user = value;
				OnPropertyChanged(nameof(User));
			}
		}

        

        private string _firstName;



        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(User.FirstName));
            }
        }

        private string _lastName;
		public string LastName
		{
			get { return _lastName; }
			set
			{
				_lastName = value;
				OnPropertyChanged(nameof(User.LastName));
			}
		}

		

        public EmployeeListingItemViewModel(User user)
        {
            User = user;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}
