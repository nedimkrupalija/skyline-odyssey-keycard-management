using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class EmployeePanelViewModel : ViewModelBase
    {
        private ICollection<UsageHistory> usageHistories;

        public ICollection<UsageHistory> UsageHistories
        {
            get { return usageHistories; }
            set
            {
                if (usageHistories != value)
                {
                    usageHistories = value;
                    OnPropertyChanged(nameof(UsageHistories));
                }
            }
        }

        public EmployeePanelViewModel()
        {
            DatabaseContext databaseContext = new DatabaseContext();
            UsageHistories = databaseContext.UsageHistories.ToList();
          UsageHistories = databaseContext.UsageHistories.Include(u => u.User).Include(u => u.AccessPoint).Where(u => u.User.UserId == LoginView.LoggedInUser.UserId).ToList();
        }
    }
}
