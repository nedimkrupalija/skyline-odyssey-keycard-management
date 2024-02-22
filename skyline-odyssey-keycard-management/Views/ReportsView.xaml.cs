using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace skyline_odyssey_keycard_management.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {

        public List<int> Hours { get; } = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 00 };
        public List<int> Minutes { get; } = new List<int> { 0, 15, 30, 45 };


        private DatabaseContext _databaseContext = new DatabaseContext();
        public UsageReportsListingViewModel UsageReportsListingViewModel { get; set; }
        private ObservableCollection<UsageReportsListingItemViewModel> _usageReportsListingItemViewModels;

        public ObservableCollection<UsageReportsListingItemViewModel> UsageReportsListingItemViewModels
        {
            get { return _usageReportsListingItemViewModels; }
            set { _usageReportsListingItemViewModels = value; }
        }

        public event Action UsageReportsFiltered;

        //public IEnumerable<UsageReportsListingItemViewModel> UsageReportsListingItemViewModels => _usageReportsListingItemViewModels;

        public ReportsView()
        {
            InitializeComponent();

            UsageReportsListingViewModel = new UsageReportsListingViewModel();
            _usageReportsListingItemViewModels = new ObservableCollection<UsageReportsListingItemViewModel>();
            DataContext = this;

            var usagereports = _databaseContext.UsageHistories.Include(u => u.AccessPoint).Include(u => u.Keycard).ToList();
            _usageReportsListingItemViewModels = new ObservableCollection<UsageReportsListingItemViewModel>();
            foreach (var usagereport in usagereports)
            {
                _usageReportsListingItemViewModels.Add(new UsageReportsListingItemViewModel(usagereport));

            }


        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            MainAdminView mainAdminPanel = new MainAdminView();
            mainAdminPanel.Width = this.Width;
            mainAdminPanel.Height = this.Height;

            this.Content = mainAdminPanel;
        }
        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilterUsageReports();
        }


        private void FilterUsageReports()
        {
            var startDate = startDatePicker.SelectedDate;
            var endDate = endDatePicker.SelectedDate;

            int startHour = Convert.ToInt32(startHours.SelectedValue);
            int startMinute = Convert.ToInt32(startMinutes.SelectedValue);
            int endHour = Convert.ToInt32(endHours.SelectedValue);
            int endMinute = Convert.ToInt32(endMinutes.SelectedValue);

            Trace.WriteLine("start hour: " + startHour);
            Trace.WriteLine("start min: " + startMinute);
            Trace.WriteLine("end hour: " + endHour);
            Trace.WriteLine("end hour: " + endMinute);

            _usageReportsListingItemViewModels.Clear();


            if (startDate != null || endDate != null)
            {
                var usageReports = _databaseContext.UsageHistories
                            .Include(u => u.AccessPoint)
                            .Include(u => u.Keycard)
                            .Where(u => u.Timestamp >= startDate && u.Timestamp <= endDate)
                            .ToList();


                if (usageReports.Any())
                {
                    foreach (var usageReport in usageReports)
                    {
                        _usageReportsListingItemViewModels.Add(new UsageReportsListingItemViewModel(usageReport));
                        Trace.WriteLine($"Access Point: {usageReport.AccessPoint.Name}");
                        Trace.WriteLine($"Keycard: {usageReport.Keycard.Id}");
                        Trace.WriteLine($"Timestamp: {usageReport.Timestamp}");
                    }
                }
                else
                {
                    Trace.WriteLine("The usageReports list is empty.");
                }
            }
            else if (startHour >= 0 && startHour <= 23 && endHour >= 0 && endHour <= 23)
            {
                DateTime startDateTime = DateTime.Today.AddHours(startHour).AddMinutes(startMinute);
                DateTime endDateTime = DateTime.Today.AddHours(endHour).AddMinutes(endMinute);

                Trace.WriteLine("start date: " + startDateTime);
                Trace.WriteLine("end date: " + endDateTime);

                var usageReports = _databaseContext.UsageHistories
                    .Include(u => u.AccessPoint)
                    .Include(u => u.Keycard)
                    .Where(u => u.Timestamp >= startDateTime && u.Timestamp <= endDateTime)
                    .ToList();

                Trace.WriteLine("usage reports: " + usageReports.Count);

                if (usageReports.Any())
                {
                    foreach (var usageReport in usageReports)
                    {
                        _usageReportsListingItemViewModels.Add(new UsageReportsListingItemViewModel(usageReport));
                        Trace.WriteLine($"Access Point: {usageReport.AccessPoint.Name}");
                        Trace.WriteLine($"Keycard: {usageReport.Keycard.Id}");
                        Trace.WriteLine($"Timestamp: {usageReport.Timestamp}");
                    }
                }
                else
                {
                    Trace.WriteLine("The list is empty.");
                }
            }
            else
            {
                DateTime startDateTime = startDate.Value.Date.AddHours(startHour).AddMinutes(startMinute);
                DateTime endDateTime = endDate.Value.Date.AddHours(endHour).AddMinutes(endMinute);

                Trace.WriteLine("start date: " + startDateTime);
                Trace.WriteLine("end date: " + endDateTime);

                var usageReports = _databaseContext.UsageHistories
                    .Include(u => u.AccessPoint)
                    .Include(u => u.Keycard)
                    .Where(u => u.Timestamp >= startDateTime && u.Timestamp <= endDateTime)
                    .ToList();

                Trace.WriteLine("usage reports: " + usageReports.Count);

                if (usageReports.Any())
                {
                    foreach (var usageReport in usageReports)
                    {
                        _usageReportsListingItemViewModels.Add(new UsageReportsListingItemViewModel(usageReport));
                        Trace.WriteLine($"Access Point: {usageReport.AccessPoint.Name}");
                        Trace.WriteLine($"Keycard: {usageReport.Keycard.Id}");
                        Trace.WriteLine($"Timestamp: {usageReport.Timestamp}");
                    }
                }
                else
                {
                    Trace.WriteLine("The list is empty.");
                }

                UsageReportsFiltered?.Invoke();

            }
        }

        
    }
}
