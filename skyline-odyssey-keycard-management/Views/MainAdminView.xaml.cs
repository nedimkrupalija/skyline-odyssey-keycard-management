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

            LoginView.LoggedInUser.UsageHistories.Add(new UsageHistory(LoginView.LoggedInUser.Keycard.Id, DateTime.Now, 5,"Out")); 

            _databaseContext.Update(LoginView.LoggedInUser);

            _databaseContext.SaveChanges();
            this.Content = loginView;
        }

        public void LoadColumnChartData()
        {
            ((ColumnSeries)columnChart.Series[0]).ItemsSource = new ChartDataViewModel[]
    {
        new ChartDataViewModel { Key = "Project Manager", Value = 12 },
        new ChartDataViewModel { Key = "CEO", Value = 25 },
        new ChartDataViewModel { Key = "Software Engg.", Value = 5 },
        new ChartDataViewModel { Key = "Team Leader", Value = 6 },
        new ChartDataViewModel { Key = "Project Leader", Value = 10 },
        new ChartDataViewModel { Key = "Developer", Value = 4 }
    };
        }
    }
}
