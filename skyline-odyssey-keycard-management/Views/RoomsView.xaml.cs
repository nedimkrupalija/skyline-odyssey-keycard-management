using skyline_odyssey_keycard_management.Components;
using skyline_odyssey_keycard_management.Models;
using skyline_odyssey_keycard_management.Store;
using skyline_odyssey_keycard_management.ViewModels;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for RoomsView.xaml
    /// </summary>
    public partial class RoomsView : UserControl
    {

        private readonly SelectedAccessPointStore selectedAccessPointStore = new SelectedAccessPointStore();
        public AccessPointListingViewModel AccessPointListingViewModel { get; set; }
        private DatabaseContext _databaseContext;
        public RoomsView()
        {
            InitializeComponent();
            AccessPointListingViewModel = new AccessPointListingViewModel(selectedAccessPointStore);
            var viewModel = new EmployeePanelView();
            DataContext = this;

            



            _databaseContext = new DatabaseContext();   
        }

        private void BackButton_Clicked(object sender, RoutedEventArgs e)
        {
            EmployeePanelView employeePanel = new EmployeePanelView();
            employeePanel.Width = this.Width;
            employeePanel.Height = this.Height;

            this.Content = employeePanel;
        }

		private void enterRoom_Click(object sender, RoutedEventArgs e)
		{
            var user = LoginView.LoggedInUser;


            var clickedRoom = (AccessPointListingItemViewModel)roomListView.SelectedItem; 


            if(user.RoleId >= clickedRoom.AccessLevel)
            {
				user.IsInRoom = true;
                enterRoom.IsEnabled = false;

               
			}
			else
            {
				foreach (var manager in MainWindow.Managers)
				{
					MainWindow.Send_Email(manager.Email, "Unauthorized access", user.Role.Name + " " + user.FirstName + " " + user.LastName + " tried to access room " + clickedRoom.Name + " without not high enough clearence level.");
				}

			
			}

          





		}
	}
}
