using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Commands;
using System.Diagnostics;
using Microsoft.IdentityModel.Tokens;

namespace skyline_odyssey_keycard_management.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        public List<int> Hours { get; } = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 00 };
        private ICollection<UsageHistory> _usageReportsListingItemViewModels;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _selectedStartHour;
        private string _selectedEndHour;
        private string _nameFilter;

        private string _nameOfUser;

        public string NameOfUser
        {
            get
            {
                return _nameOfUser;
            }
            set
            {
                if (_nameOfUser != value)
                {
                    _nameOfUser = value;
                    OnPropertyChanged(nameof(NameOfUser));
                }
            }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        public string SelectedStartHour
        {
            get { return _selectedStartHour; }
            set
            {
                if (_selectedStartHour != value)
                {
                    _selectedStartHour = value;
                    OnPropertyChanged(nameof(SelectedStartHour));
                }
            }
        }

        public string SelectedEndHour
        {
            get { return _selectedEndHour; }
            set
            {
                if (_selectedEndHour != value)
                {
                    _selectedEndHour = value;
                    OnPropertyChanged(nameof(SelectedEndHour));
                }
            }
        }

        public string NameFilter
        {
            get { return _nameFilter; }
            set
            {
                if (_nameFilter != value)
                {
                    _nameFilter = value;
                    OnPropertyChanged(nameof(NameFilter));
                }
            }
        }

        public ICollection<UsageHistory> UsageHistoryList
        {
            get { return _usageReportsListingItemViewModels; }
            set
            {
                if (_usageReportsListingItemViewModels != value)
                {
                    _usageReportsListingItemViewModels = value;
                    OnPropertyChanged(nameof(UsageHistoryList));
                }
            }
        }

        public ReportsViewModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            SelectedStartHour = "7";
            SelectedEndHour = "18";
            DatabaseContext db = new DatabaseContext();
            UsageHistoryList = db.UsageHistories.Include(u => u.AccessPoint).Include(u => u.Keycard).ThenInclude(u => u.User).Where(u => (SelectedStartHour == null || u.Timestamp.Hour >= int.Parse(SelectedStartHour))
                                    && (SelectedEndHour == null || u.Timestamp.Hour < int.Parse(SelectedEndHour))).ToList();
        }
        public ICommand GenerateReportCommand => new RelayCommand(GenerateReport, CanGenerateReport);

        private void GenerateReport(object? parameter)
        {
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var toBeFilteredReports = dbContext.UsageHistories.Include(s => s.AccessPoint).Include(u => u.User)
                        .Where(u => u.Timestamp.Date >= StartDate.Date
                                    && u.Timestamp.Date <= EndDate.Date
                                    && (SelectedStartHour == null || u.Timestamp.Hour >= int.Parse(SelectedStartHour))
                                    && (SelectedEndHour == null || u.Timestamp.Hour < int.Parse(SelectedEndHour))
                                    )
                        .ToList();

                    var filteredReports = new List<UsageHistory>();

                    if (!NameFilter.IsNullOrEmpty())
                    {
                        foreach (var filter in toBeFilteredReports)
                        {
                            var filteredName = filter.User.FirstName + " " + filter.User.LastName;
                            Trace.WriteLine(filteredName);

                            if (filteredName.Contains(NameFilter.Trim()))
                            {
                                filteredReports.Add(filter);
                            }
                        }
                    }


                    UsageHistoryList = NameFilter.IsNullOrEmpty() ? toBeFilteredReports : filteredReports;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private bool CanGenerateReport(object? sender)
        {
            return true;
        }
    }
}
