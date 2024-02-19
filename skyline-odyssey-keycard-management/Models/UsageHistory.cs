using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.Models
{
	public class UsageHistory
	{
        public UsageHistory()
        {
            
        }
        [Key]
		public int Id { get; set; }

		[ForeignKey("User")]
		public int UserId { get; set; }	

		public User User { get; set; }

		[ForeignKey("Keycard")]
		public int CardId { get; set; }

		public Keycard Keycard { get; set; }	

		public DateTime Timestamp { get; set; }
	}
}
