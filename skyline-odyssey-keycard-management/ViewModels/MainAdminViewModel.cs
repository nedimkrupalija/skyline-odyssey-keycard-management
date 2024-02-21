using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace skyline_odyssey_keycard_management.ViewModels
{
	public class MainAdminViewModel : ViewModelBase
	{

		private DatabaseContext _databaseContext = new DatabaseContext();	
		public MainAdminViewModel()
		{
			
			var tempUsers = _databaseContext.Users.Include(u=>u.UsageHistories).ToList();
			tempUsers.RemoveAll(p => p.IsOnline == false);
			var tempUsageHistories = new ObservableCollection<UsageHistory>();
			foreach (var user in tempUsers)
			{
				Trace.WriteLine("ABC" + user.UsageHistories.Count + "ABC");
				if (user.UsageHistories.Count > 0)
				{
					

					for (int i = user.UsageHistories.Count - 1; i >= 0; i--)
					{
						if (user.UsageHistories.ElementAt(i).AccessPointId==5)
						{
							tempUsageHistories.Add(user.UsageHistories.ElementAt(i));
							break;
						}
					}
				}
			}

			
			UsageHistories = tempUsageHistories;
			Users = new ObservableCollection<User>(tempUsers);
		}
		private ICollection<UsageHistory> _usageHistories;	
		public ICollection<UsageHistory> UsageHistories
		{
			get { return _usageHistories; }
			set
			{
				_usageHistories = value;
				OnPropertyChanged(nameof(UsageHistories));
			}
		}


		public ICollection<User> _users;
		public ICollection<User> Users
		{
			get { return _users; }
			set
			{
				_users = value;
				
				OnPropertyChanged(nameof(Users));
			}
		}		
	}	
	
}
