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
    public class AccessPointDetailsViewModel : ViewModelBase
    {
        private readonly SelectedAccessPointStore _selectedAccessPointStore;
        public bool HasSelectedAccessPoint => _selectedAccessPointStore.SelectedAccessPoint != null;

        public string Name => _selectedAccessPointStore.SelectedAccessPoint?.Name?? "Unkown";
        public int AccessLevel => _selectedAccessPointStore.SelectedAccessPoint?.AccessLevel ?? 0;

        public ICollection<UsageHistory> UsageHistories => (_selectedAccessPointStore.SelectedAccessPoint?.UsageHistories ?? new ObservableCollection<UsageHistory>());
        public AccessPoint AccessPoint => _selectedAccessPointStore.SelectedAccessPoint?.accessPoint ?? new AccessPoint();
        public Keycard Keycard => _selectedAccessPointStore.SelectedAccessPoint?.keycard ?? new Keycard();
        

        public string Username => _selectedAccessPointStore.SelectedAccessPoint?.keycard?.User?.FirstName?? "Unkown";

        public AccessPointDetailsViewModel(SelectedAccessPointStore selectedAccessPointStore)
        {
            _selectedAccessPointStore = selectedAccessPointStore;

            _selectedAccessPointStore.SelectedAccessPointChanged += _selectedAccessPointStore_SelectedAccessPointChanged; ;
        }

        private void _selectedAccessPointStore_SelectedAccessPointChanged()
        {
            OnPropertyChanged(nameof(HasSelectedAccessPoint));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(AccessPoint));
            OnPropertyChanged(nameof(AccessLevel));
            OnPropertyChanged(nameof(Keycard));
            OnPropertyChanged(nameof(UsageHistories));
            OnPropertyChanged(nameof(Username));
           
        }

        protected override void Dispose()
        {
            _selectedAccessPointStore.SelectedAccessPointChanged -= _selectedAccessPointStore_SelectedAccessPointChanged; ;
            base.Dispose();
        }
    }
}
