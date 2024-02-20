using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.Models
{
	public class AccessPoint
	{
		[Key]
		public int Id { get; set; }

		public int AccessLevel { get; set; }

        public string Name { get; set; }

        public AccessPoint()
        {
            
        }

        public AccessPoint(int id, int accessLevel, string name)
        {
            Id = id;
            AccessLevel = accessLevel;
            Name = name;
        }
    }
}
