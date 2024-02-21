using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.Store
{
    public class SelectedAccessPointStore
    {
        private AccessPoint _selectedAccessPoint;

        public AccessPoint SelectedAccessPoint
        {
            get
            {
                return _selectedAccessPoint;
            }
            set
            {
                _selectedAccessPoint = value;
                SelectedAccessPointChanged?.Invoke();
            }
        }

        public event Action SelectedAccessPointChanged;
    }
}
