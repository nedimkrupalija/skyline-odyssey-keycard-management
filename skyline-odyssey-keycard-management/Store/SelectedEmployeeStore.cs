using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.Store
{
    public class SelectedEmployeeStore
    {
        private User _selectedEmployee;

        public User SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            } set
            {
                _selectedEmployee = value;
                SelectedEmployeeChanged?.Invoke();
            }
        }

        public event Action SelectedEmployeeChanged;
    }
}
