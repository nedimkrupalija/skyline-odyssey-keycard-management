using skyline_odyssey_keycard_management.Components;
using skyline_odyssey_keycard_management.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class EmployeesViewModel
    {
        public EmployeeDetailsViewModel EmployeeDetailsViewModel { get; set; }
        public EmployeeListingViewModel EmployeeListingViewModel { get; set; }

        public ICommand AddNewEmployeeCommand { get; }

        public ICommand DeactivateKeycardCommand { get; }

        public ICommand AssignNewKeycardCommand { get; }

        public EmployeesViewModel(SelectedEmployeeStore selectedEmployeeStore) {
            EmployeeListingViewModel = new EmployeeListingViewModel(selectedEmployeeStore);
            EmployeeDetailsViewModel = new EmployeeDetailsViewModel(selectedEmployeeStore);
        }
    }
}
