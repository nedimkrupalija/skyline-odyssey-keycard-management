using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    /// Interaction logic for MainAdminView.xaml
    /// </summary>
    public partial class MainAdminView : UserControl
    {
        private DatabaseContext _databaseContext;
        public MainAdminView()
        {
            InitializeComponent();
            var viewModel = new MainAdminViewModel();
            this.DataContext = viewModel;
            _databaseContext = new DatabaseContext();
            LoadColumnChartData();
        }


        private void Emloyees_CLicked(object sender, RoutedEventArgs e)
        {
            AdminPanelView adminPanel = new AdminPanelView();
            adminPanel.Width = this.Width;
            adminPanel.Height = this.Height;

            this.Content = adminPanel;
        }

        private void AccessPoints_Clicked(object sender, RoutedEventArgs e)
        {
            AccessPointsView accessPointsPanel = new AccessPointsView();
            accessPointsPanel.Width = this.Width;
            accessPointsPanel.Height = this.Height;

            this.Content = accessPointsPanel;
        }

        private void Reports_Clicked(object sender, RoutedEventArgs e)
        {
            ReportsView reportsPanel = new ReportsView();
            reportsPanel.Width = this.Width;
            reportsPanel.Height = this.Height;

            this.Content = reportsPanel;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

            LoginView loginView = new LoginView();
            LoginView.LoggedInUser.IsOnline = false;
            Trace.WriteLine(LoginView.LoggedInUser);
            LoginView.LoggedInUser.UsageHistories.Add(new UsageHistory(LoginView.LoggedInUser.Keycard.Id, DateTime.Now, 5, "Out"));

            _databaseContext.Update(LoginView.LoggedInUser);

            _databaseContext.SaveChanges();
            this.Content = loginView;
        }

        private void LoadColumnChartData()
        {
            DatabaseContext dbcontext = new DatabaseContext();
            DateTime currentDate = DateTime.Now;

            DateTime previousMonday = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday - 7);
            DateTime previousTuesday = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday - 6);
            DateTime previousWednesday = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday - 5);
            DateTime previousThursday = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday - 4);
            DateTime previousFriday = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday - 3);


            var mondayCount = dbcontext.UsageHistories.Include(x => x.AccessPoint)
                .Where(e => e.AccessPoint.Name.Equals("Main enterance") && e.Timestamp.Day.ToString() == previousMonday.Day.ToString())
                .ToList();
            var tuesdayCount = dbcontext.UsageHistories.Include(x => x.AccessPoint)
                .Where(e => e.AccessPoint.Name.Equals("Main enterance") && e.Timestamp.Day.ToString() == previousTuesday.Day.ToString())
                .ToList();
            var wednesdayCount = dbcontext.UsageHistories.Include(x => x.AccessPoint)
                .Where(e => e.AccessPoint.Name.Equals("Main enterance") && e.Timestamp.Day.ToString() == previousWednesday.Day.ToString())
                .ToList();
            var thursdayCount = dbcontext.UsageHistories.Include(x => x.AccessPoint)
                .Where(e => e.AccessPoint.Name.Equals("Main enterance") && e.Timestamp.Day.ToString() == previousThursday.Day.ToString())
                .ToList();
            var fridayCount = dbcontext.UsageHistories.Include(x => x.AccessPoint)
                .Where(e => e.AccessPoint.Name.Equals("Main enterance") && e.Timestamp.Day.ToString() == previousFriday.Day.ToString())
                .ToList();
        
            ((ColumnSeries)columnChart.Series[0]).ItemsSource = new ChartDataViewModel[]
            {
                new ChartDataViewModel { Key = "Mon", Value = mondayCount.Count},
                new ChartDataViewModel { Key = "Tue", Value = tuesdayCount.Count },
                new ChartDataViewModel { Key = "Wed", Value = wednesdayCount.Count },
                new ChartDataViewModel { Key = "Thu", Value = thursdayCount.Count },
                new ChartDataViewModel { Key = "Fri", Value = fridayCount.Count },
            };
        }
        

    }
}
