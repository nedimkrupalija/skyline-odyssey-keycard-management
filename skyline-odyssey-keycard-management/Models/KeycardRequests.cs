using skyline_odyssey_keycard_management.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.Models
{
	public class KeycardRequests
	{

      public KeycardRequests(int userId, string reason, string status)
        {

			UserId = userId;
			Reason = reason;
			Status = status;
            
        }

        public KeycardRequests()
        {
            
        }

        public int Id { get; set; }

		
		public int UserId { get; set; }
		public User User{ get; set; } 


		public string Reason { get; set; }


		public string Status { get; set; }	

		
	}
}
