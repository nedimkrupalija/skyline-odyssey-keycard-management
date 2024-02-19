using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class EmployeeListingViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeListingItemViewModel> _employeeListingItemViewModels;

        public IEnumerable<EmployeeListingItemViewModel> EmployeeListingItemViewModels => _employeeListingItemViewModels;


        public EmployeeListingViewModel()
        {
            _employeeListingItemViewModels = new ObservableCollection<EmployeeListingItemViewModel>
            {
                new EmployeeListingItemViewModel(new User(1, "Sara", "Nalo", "test1username", "test1pw", 1, new Role(), 1, new Keycard())),
                new EmployeeListingItemViewModel(new User(2, "Nedim", "Krupalija", "test2username", "test2pw", 1, new Role(), 2, new Keycard())),
                new EmployeeListingItemViewModel(new User(3, "Almedin", "Pasalic", "test3username", "test3pw", 3, new Role(), 3, new Keycard())),
                new EmployeeListingItemViewModel(new User(3, "Ilhan", "Hasicic", "test3username", "test3pw", 3, new Role(), 4, new Keycard())),
            };
        }
    }
}
