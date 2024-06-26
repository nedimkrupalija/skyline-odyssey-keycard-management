﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace skyline_odyssey_keycard_management.Models
{
	public class User
	{
        public User()
        {
            
        }

        public User(int userId, string firstName, string lastName, string username, string password, int roleId, Role role, int keycardId, Keycard keycard)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            RoleId = roleId;
            Role = role;
            KeycardId = keycardId;
            Keycard = keycard;
        }

		public User( string firstName, string lastName, string username, string password, int roleId, Role role, int keycardId, Keycard keycard, string email)
		{
			
			FirstName = firstName;
			LastName = lastName;
			Username = username;
			Password = password;
			RoleId = roleId;
			Role = role;
			KeycardId = keycardId;
			Keycard = keycard;
			Email = email;
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int UserId { get; set; }
		public string FirstName { get; set; }

		public string LastName { get; set; }
		
		public string Username { get; set; }
		public string Password { get; set; }

		[ForeignKey("Role")]
		public int RoleId { get; set; }
		public Role Role { get; set; }

		[ForeignKey("Keycard")]
		public int KeycardId { get; set; }

		public Keycard Keycard { get; set; }
		
		public Boolean IsOnline { get; set; }	
		public string Email { get; set; }

		public Boolean IsInRoom { get; set; }

		

		public ICollection<UsageHistory> UsageHistories { get; set; }	

	}
}
