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
    /// Interaction logic for EmployeePanelView.xaml
    /// </summary>
    public partial class EmployeePanelView : UserControl
    {

        private DatabaseContext _databaseContext;

        public RoomsViewModel RoomsViewModel { get; set; }
        public EmployeePanelView()
        {
            InitializeComponent();

            var viewModel = new RoomsViewModel();
            this.DataContext = viewModel;

            this.DataContext = new EmployeePanelViewModel();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new MainAdminView();

        }

        private void EnterRoom_Clicked(object sender, RoutedEventArgs e)
        {
            RoomsView roomsViewModel = new();
            roomsViewModel.Width = this.Width;
            roomsViewModel.Height = this.Height;

            this.Content = roomsViewModel;
        }




        private void Logout_Clicked(object sender, RoutedEventArgs e)
        {
            DatabaseContext _databaseContext = new DatabaseContext();
            LoginView loginView = new LoginView();
            LoginView.LoggedInUser.IsOnline = false;
            LoginView.LoggedInUser.UsageHistories.Add(new UsageHistory(LoginView.LoggedInUser.Keycard.Id, DateTime.Now, 5, "Out"));
            _databaseContext.Update(LoginView.LoggedInUser);
            _databaseContext.SaveChanges();
            this.Content = loginView;
        }

		private void Request_Click(object sender, RoutedEventArgs e)
		{
            
		}
	}

    
}
