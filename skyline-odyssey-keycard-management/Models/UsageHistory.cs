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

        public UsageHistory(int cardId, DateTime timestamp, int accessPointId, Boolean isEntry)
        {
            CardId = cardId;
			Timestamp = timestamp;
			AccessPointId = accessPointId;
			IsEntry	= isEntry;

        }
        [Key]
		public int Id { get; set; }

		

		[ForeignKey("Keycard")]
		public int CardId { get; set; }

		public Keycard Keycard { get; set; }	

		public DateTime Timestamp { get; set; }


		[ForeignKey("AcessPoint")]
		public int AccessPointId { get; set; }

		public AccessPoint AccessPoint { get; set; }

		public Boolean IsEntry { get; set; }


	}
}
