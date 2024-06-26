﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Views;
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

			Firstname = LoginView.LoggedInUser.FirstName;
			Lastname = LoginView.LoggedInUser.LastName;
			UsageHistories = tempUsageHistories;
			



			
			
			



		}

		private string _fullName;

		public string FullName
		{
			get { return _fullName; }
			set
			{
				_fullName = value;
				OnPropertyChanged(nameof(FullName));
			}
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


		private string _firstname;
		public string Firstname
		{
			get { return _firstname; }
			set
			{
				_firstname = value;
				OnPropertyChanged(nameof(Firstname));
			}
		}
		
		private string _lastname;	
		public string Lastname
		{
			get { return _lastname; }
			set
			{
				_lastname = value;
				OnPropertyChanged(nameof(Lastname));
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
