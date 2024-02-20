﻿using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class EmployeeDetailsViewModel : ViewModelBase
    {
        private readonly SelectedEmployeeStore _selectedEmployeeStore;
        public bool HasSelectedEmployee => _selectedEmployeeStore.SelectedEmployee != null;
        public string FirstName => _selectedEmployeeStore.SelectedEmployee?.FirstName ?? "Unkown";
        public string LastName => _selectedEmployeeStore.SelectedEmployee?.LastName ?? "Unkown";
        public string Username => _selectedEmployeeStore.SelectedEmployee?.Username ?? "Unkown";
        public Role Role => _selectedEmployeeStore.SelectedEmployee?.Role ?? new Role();
        public Keycard Keycard => _selectedEmployeeStore.SelectedEmployee?.Keycard ?? new Keycard();

        public EmployeeDetailsViewModel(SelectedEmployeeStore selectedEmployeeStore)
        {
            _selectedEmployeeStore = selectedEmployeeStore;

            _selectedEmployeeStore.SelectedEmployeeChanged += SelectedEmployeeStore_SelectedEmployeeChanged;
        }

        protected override void Dispose()
        {
            _selectedEmployeeStore.SelectedEmployeeChanged -= SelectedEmployeeStore_SelectedEmployeeChanged; 
            base.Dispose();
        }
        private void SelectedEmployeeStore_SelectedEmployeeChanged()
        {
            OnPropertyChanged(nameof(HasSelectedEmployee));
            OnPropertyChanged(nameof(FirstName)); 
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(Role));
            OnPropertyChanged(nameof(Keycard));
        }
    }
}
