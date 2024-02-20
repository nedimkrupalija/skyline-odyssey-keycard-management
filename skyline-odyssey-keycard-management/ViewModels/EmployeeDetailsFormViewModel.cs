using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class EmployeeDetailsFormViewModel : ViewModelBase
    {
        private string _firstName;

        public string FirstName
        {
            get { 
                return _firstName;
            }
            set { 
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _role;

        public string Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(FirstName);

        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
