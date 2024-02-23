using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class KeycardRequestsViewModel : ViewModelBase
    {
        private ICollection<KeycardRequests> _keycardRequests;
        public ICollection<KeycardRequests> KeycardRequests
        {
            get
            {
                return _keycardRequests;
            }
            set
            {
                if (_keycardRequests != value)
                {
                    _keycardRequests = value;
                    OnPropertyChanged(nameof(KeycardRequests));
                }
            }

        }

        public KeycardRequestsViewModel()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            var keycardRequests = databaseContext.KeycardRequests.Include(u => u.User).ToList();
            KeycardRequests = keycardRequests;
        }
    }
}
