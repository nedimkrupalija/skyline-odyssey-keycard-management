using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Store;
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
        private readonly SelectedEmployeeStore _selectedEmployeeStore;
        private ObservableCollection<EmployeeListingItemViewModel> _employeeListingItemViewModels;

        public IEnumerable<EmployeeListingItemViewModel> EmployeeListingItemViewModels => _employeeListingItemViewModels;

        private DatabaseContext _databaseContext = new DatabaseContext();

        private EmployeeListingItemViewModel _selectedEmployeeListingItemViewModel;
        public EmployeeListingItemViewModel SelectedEmployeeListingItemViewModel
        {
            get
            {
                return _selectedEmployeeListingItemViewModel;
            }
            set
            {
                _selectedEmployeeListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedEmployeeListingItemViewModel));
                _selectedEmployeeStore.SelectedEmployee = _selectedEmployeeListingItemViewModel?.User;
            }
        }
        public EmployeeListingViewModel(SelectedEmployeeStore selectedEmployeeStore)
        {
            _selectedEmployeeStore = selectedEmployeeStore;
            var users = _databaseContext.Users.ToList();
            _employeeListingItemViewModels = new ObservableCollection<EmployeeListingItemViewModel>();
            foreach(var user in users)
            {
                _employeeListingItemViewModels.Add(new EmployeeListingItemViewModel(user));
            }
           
        }
    }
}
