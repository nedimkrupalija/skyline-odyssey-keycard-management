using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        public EmployeeDetailsFormViewModel EmployeeDetailsFormViewModel { get; }

        public AddEmployeeViewModel()
        {
            EmployeeDetailsFormViewModel = new EmployeeDetailsFormViewModel();
        }
    }
}
