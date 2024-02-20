using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class EmployeeListingViewModel : ViewModelBase
    {
        private ObservableCollection<EmployeeListingItemViewModel> _employeeListingItemViewModels;

        public IEnumerable<EmployeeListingItemViewModel> EmployeeListingItemViewModels => _employeeListingItemViewModels;

        private DatabaseContext _databaseContext = new DatabaseContext();

        public EmployeeListingViewModel()
        {
            var users = _databaseContext.Users.ToList();
            _employeeListingItemViewModels = new ObservableCollection<EmployeeListingItemViewModel>();
            foreach(var user in users)
            {
                _employeeListingItemViewModels.Add(new EmployeeListingItemViewModel(user));
            }
           
        }
    }
}
