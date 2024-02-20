using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.Models
{
	public class Keycard
	{
        public Keycard()
        {
            
        }

        [Key]
		public int Id { get; set; }


		public Boolean IsAssigned { get; set; }

		public ICollection<UsageHistory> UsageHistories { get; set; }
		
	}
}
