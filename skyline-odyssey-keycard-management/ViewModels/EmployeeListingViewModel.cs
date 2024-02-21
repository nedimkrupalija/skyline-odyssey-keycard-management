using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Store;
using skyline_odyssey_keycard_management.Views;
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

            var users = _databaseContext.Users.Include(u => u.Keycard).Include(u => u.Role).Include(u => u.UsageHistories).ToList();

            var usageHistories = _databaseContext.UsageHistories.Include(u => u.AccessPoint).ToList();

            for(int i = 0; i < users.Count; i++)
            {
                users[i].UsageHistories = usageHistories.FindAll(u => u.CardId  == users[i].KeycardId);
                
            }


            _employeeListingItemViewModels = new ObservableCollection<EmployeeListingItemViewModel>();
            foreach (var user in users)
            {


                if(LoginView.LoggedInUser.Role.Id > user.Role.Id)
                _employeeListingItemViewModels.Add(new EmployeeListingItemViewModel(user));
            }

        }
    }
}