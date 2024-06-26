﻿using skyline_odyssey_keycard_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class UsageReportsListingItemViewModel : ViewModelBase
    {

        public UsageHistory UsageHistory { get; set; }

        public int AccessLevel => UsageHistory.AccessPoint.AccessLevel;

        public string Name => UsageHistory.AccessPoint.Name;

        public DateTime Timestamp => UsageHistory.Timestamp;

        public int Keycard => UsageHistory.Keycard.Id;

        public UsageReportsListingItemViewModel(UsageHistory usageHistory)
        {
            UsageHistory = usageHistory;
        }
    }
}
