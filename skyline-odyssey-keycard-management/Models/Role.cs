using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.Models
{
	
	public class Role
	{
        public Role()
        {
            
        }
        [Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public ICollection<User> Users { get; set; }	

	}
}
