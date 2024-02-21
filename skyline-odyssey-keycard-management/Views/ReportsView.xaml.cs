using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private DatabaseContext databaseContext = new DatabaseContext();
        public UsageReportsListingViewModel UsageReportsListingViewModel { get; set; }
        private ObservableCollection<UsageReportsListingItemViewModel> _usageReportsListingItemViewModels;

        public IEnumerable<UsageReportsListingItemViewModel> UsageReportsListingItemViewModels => _usageReportsListingItemViewModels;

        public ReportsView()
        {
            InitializeComponent();

            UsageReportsListingViewModel = new UsageReportsListingViewModel();
            DataContext = this;
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
            Trace.WriteLine("Click");
            var startDate = startDatePicker.SelectedDate;
            Trace.WriteLine(startDate);
            var endDate = endDatePicker.SelectedDate;
            Trace.WriteLine(endDate);
            var usageReports = databaseContext.UsageHistories
                            .Include(u => u.AccessPoint)
                            .Include(u => u.Keycard)
                            .Where(u => u.Timestamp >= startDate && u.Timestamp <= endDate)
                            .ToList();
            
            foreach (var usageReport in usageReports)
            {
                _usageReportsListingItemViewModels.Add(new UsageReportsListingItemViewModel(usageReport));
            }

        }
    }
}
