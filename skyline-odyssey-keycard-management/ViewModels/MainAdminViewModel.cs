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
			Trace.WriteLine("CONSTRUCTOR CALLED");
			var tempUsers = _databaseContext.Users.ToList();	
			Users = new ObservableCollection<User>(tempUsers);
		}

		public ICollection<User> _users;
		public ICollection<User> Users
		{
			get { return _users; }
			set
			{
				_users = value;
				Trace.WriteLine("818418481" + Users.Count);
				OnPropertyChanged(nameof(Users));
			}
		}		
	}	
	
}
